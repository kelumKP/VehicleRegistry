using MediatR;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category;
using VehicleRegistry.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleRegistry.Core.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;

        public CreateCategoryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<CategoryDetailsDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request != null && request.NewCategory.CategoryId <= 0)
            {
                if (request.NewCategory.RangeTo == null)
                {
                    var lastCategory = _ctx.Categories.Where(cat => cat.RangeTo == null).FirstOrDefault();

                    if (lastCategory.RangeFrom < request.NewCategory.RangeFrom)
                    {
                        lastCategory.RangeTo = request.NewCategory.RangeFrom - 0.01m;
                    }
                }
                if (request.NewCategory.RangeFrom == 0.01m)
                {
                    var firstCategory = _ctx.Categories.Where(cat => cat.RangeFrom == 0.01m).FirstOrDefault();

                    if (firstCategory.RangeTo > request.NewCategory.RangeTo)
                    {
                        firstCategory.RangeFrom = request.NewCategory.RangeTo + 0.01m;
                    }
                }

                var newCategory = new Core.Models.Category
                {
                    CategoryName = request.NewCategory.CategoryName,
                    RangeFrom = request.NewCategory.RangeFrom,
                    RangeTo = request.NewCategory.RangeTo,
                    IconId = request.NewCategory.IconId
                };

                _ctx.Categories.Add(newCategory);
                await _ctx.SaveChangesAsync();

                // Now that the new category is saved, let's retrieve it from the database
                var savedCategory = await _ctx.Categories
                    .FirstOrDefaultAsync(c => c.Id == newCategory.Id);

                // Map the Category entity to a CategoryDetailsDto
                var categoryDto = new CategoryDetailsDto
                {
                    CategoryId = savedCategory.Id,
                    CategoryName = savedCategory.CategoryName,
                    RangeFrom = savedCategory.RangeFrom,
                    RangeTo = savedCategory.RangeTo,
                    IconId = savedCategory.IconId // Assuming IconId is in CategoryDetailsDto
                };

                return categoryDto;
            }

            return null;
            
        }
    }
}
