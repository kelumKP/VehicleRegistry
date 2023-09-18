using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.DAL;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Commands.UpdateCategory;
using VehicleRegistry.Application.Category.Commands.UpdateCategory.VehicleRegistry.Application.Category.Commands.UpdateCategory;
using Microsoft.EntityFrameworkCore;

namespace VehicleRegistry.Application.Category.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;

        public UpdateCategoryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<CategoryDetailsDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = _ctx.Categories.SingleOrDefault(c => c.Id == request.CategoryId);

            if (categoryToUpdate != null)
            {
                if ((categoryToUpdate.RangeFrom != request.UpdatingCategory.RangeFrom) ||
                   (categoryToUpdate.RangeTo != request.UpdatingCategory.RangeTo)) 
                {
                    if (categoryToUpdate.RangeFrom == 0.01m) 
                    {
                        var topNextItem = _ctx.Categories.Where(category => category.RangeFrom > 0.01m).OrderBy(category => category.RangeFrom).FirstOrDefault();
                        topNextItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                        categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;
                        await _ctx.SaveChangesAsync();
                    }
                    else if (categoryToUpdate.RangeTo == null) 
                    {
                        var bottomNextItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();
                        bottomNextItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                        categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;
                        await _ctx.SaveChangesAsync();
                    }
                    else
                    {
                        if ((categoryToUpdate.RangeFrom != request.UpdatingCategory.RangeFrom) && (categoryToUpdate.RangeTo != request.UpdatingCategory.RangeTo)) 
                        {
                            var closestUpperItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();
                            closestUpperItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                            categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;

                            var closestLowerItem = _ctx.Categories.Where(category => category.RangeFrom > categoryToUpdate.RangeFrom).OrderBy(category => category.RangeFrom).FirstOrDefault();
                            closestLowerItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                            categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;
                            
                            await _ctx.SaveChangesAsync();

                        }

                        if ((categoryToUpdate.RangeFrom != request.UpdatingCategory.RangeFrom)) 
                        {
                            var closestUpperItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();
                            closestUpperItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                            categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;
                            await _ctx.SaveChangesAsync();
                        }


                        if ((categoryToUpdate.RangeTo != request.UpdatingCategory.RangeTo)) 
                        {
                            var closestLowerItem = _ctx.Categories.Where(category => category.RangeFrom > categoryToUpdate.RangeFrom).OrderBy(category => category.RangeFrom).FirstOrDefault();
                            closestLowerItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                            categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;
                            await _ctx.SaveChangesAsync();
                        }

                    }
                    
                }
                if ((categoryToUpdate.CategoryName != request.UpdatingCategory.CategoryName) ||
                   (categoryToUpdate.IconId != request.UpdatingCategory.IconId)) 
                {
                    categoryToUpdate.CategoryName = request.UpdatingCategory.CategoryName;  
                    categoryToUpdate.IconId = request.UpdatingCategory.IconId;
                    await _ctx.SaveChangesAsync();
                }

            }

            return null;
        }

    }
}
