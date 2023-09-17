using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.DAL;
using VehicleRegistry.Core.Models;
using VehicleRegistry.Application.Category.Services;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Commands.UpdateCategory.VehicleRegistry.Application.Category.Commands.UpdateCategory;

namespace VehicleRegistry.Application.Category.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;
        private readonly ICategoryValidationService _categoryValidationService;

        public UpdateCategoryHandler(DataContext ctx, ICategoryValidationService categoryValidationService)
        {
            _ctx = ctx;
            _categoryValidationService = categoryValidationService;
        }

        public async Task<CategoryDetailsDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Convert existing categories to CategoryDetailsDto
            var existingCategories = _ctx.Categories
                .Select(category => new CategoryDetailsDto
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    RangeFrom = category.RangeFrom,
                    RangeTo = category.RangeTo,
                    Icon = category.Icon != null ? category.Icon.Path : null
                })
                .ToList();

            // Check if the updated category is valid
            var isValid = _categoryValidationService.IsCategoryValidForUpdate(existingCategories, request.UpdatedCategory, request.ExistingCategory);

            if (isValid)
            {
                // Update the existing Category entity
                var existingCategory = _ctx.Categories.Find(request.ExistingCategory.Id);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = request.UpdatedCategory.CategoryName;
                    existingCategory.RangeFrom = request.UpdatedCategory.RangeFrom;
                    existingCategory.RangeTo = request.UpdatedCategory.RangeTo; // Assign directly as decimal
                    // You may also update the IconId if needed
                }
                else
                {
                    // Handle the case where the existing category is not found
                    return null;
                }

                await _ctx.SaveChangesAsync();

                // Map the updated Category entity to a CategoryDetailsDto
                var updatedCategoryDto = new CategoryDetailsDto
                {
                    Id = existingCategory.Id,
                    CategoryName = existingCategory.CategoryName,
                    RangeFrom = existingCategory.RangeFrom,
                    RangeTo = existingCategory.RangeTo, // Assign directly as decimal
                    Icon = request.UpdatedCategory.Icon  // Assuming Icon is a string in CategoryDetailsDto
                };

                return updatedCategoryDto;
            }

            // Handle the case where the category update is not valid (e.g., overlaps with existing)
            // You can return an appropriate response or throw an exception based on your needs

            return null; // Return null if the category update is not valid
        }
    }
}

