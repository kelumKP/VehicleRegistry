#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using VehicleRegistry.DAL;

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
                        if ((request.UpdatingCategory.RangeTo < topNextItem.RangeTo))
                        {
                            topNextItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                            categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;
                            await _ctx.SaveChangesAsync();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (categoryToUpdate.RangeTo == null)
                    {
                        var bottomNextItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();
                        if ((request.UpdatingCategory.RangeFrom > bottomNextItem.RangeFrom))
                        {
                            bottomNextItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                            categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;
                            await _ctx.SaveChangesAsync();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        if ((categoryToUpdate.RangeFrom != request.UpdatingCategory.RangeFrom) && (categoryToUpdate.RangeTo != request.UpdatingCategory.RangeTo))
                        {
                            var closestUpperItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();
                            var closestLowerItem = _ctx.Categories.Where(category => category.RangeFrom > categoryToUpdate.RangeFrom).OrderBy(category => category.RangeFrom).FirstOrDefault();

                            if (request.UpdatingCategory.RangeFrom > closestUpperItem.RangeFrom && request.UpdatingCategory.RangeTo < closestLowerItem.RangeTo)
                            {
                                closestUpperItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                                categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;


                                closestLowerItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                                categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;

                                await _ctx.SaveChangesAsync();
                            }
                            else
                            {
                                return null;
                            }
                        }

                        if ((categoryToUpdate.RangeFrom != request.UpdatingCategory.RangeFrom))
                        {
                            var closestUpperItem = _ctx.Categories.Where(category => category.RangeFrom < categoryToUpdate.RangeFrom).OrderByDescending(category => category.RangeFrom).FirstOrDefault();

                            if (request.UpdatingCategory.RangeFrom > closestUpperItem.RangeFrom)
                            {
                                closestUpperItem.RangeTo = request.UpdatingCategory.RangeFrom - 0.01m;
                                categoryToUpdate.RangeFrom = request.UpdatingCategory.RangeFrom;
                                await _ctx.SaveChangesAsync();
                            }
                            else
                            {
                                return null;
                            }
                        }


                        if ((categoryToUpdate.RangeTo != request.UpdatingCategory.RangeTo))
                        {
                            var closestLowerItem = _ctx.Categories.Where(category => category.RangeFrom > categoryToUpdate.RangeFrom).OrderBy(category => category.RangeFrom).FirstOrDefault();

                            if (request.UpdatingCategory.RangeTo < closestLowerItem.RangeTo || closestLowerItem.RangeTo == null)
                            {
                                closestLowerItem.RangeFrom = request.UpdatingCategory.RangeTo + 0.01m;
                                categoryToUpdate.RangeTo = request.UpdatingCategory.RangeTo;
                                await _ctx.SaveChangesAsync();
                            }
                            else
                            {
                                return null;
                            }
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

                // Map the updated category to CategoryDetailsDto
                var updatedCategoryDto = new CategoryDetailsDto
                {
                    CategoryId = categoryToUpdate.Id,
                    CategoryName = categoryToUpdate.CategoryName,
                    RangeFrom = categoryToUpdate.RangeFrom,
                    RangeTo = categoryToUpdate.RangeTo,
                    IconId = categoryToUpdate.IconId // Assuming IconId is in CategoryDetailsDto
                };

                return updatedCategoryDto;
            }

            return null;
        }

    }
}

