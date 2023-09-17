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
            // Find the existing Category entity by its Id
            var existingCategoryEntity = await _ctx.Categories.FindAsync(request.CategoryId);
            if (existingCategoryEntity == null)
            {
                // Handle the case where the existing category is not found
                return null;
            }

            // Map the existing Category entity to a CategoryDetailsDto
            var existingCategory = new CategoryDetailsDto
            {
                CategoryId = existingCategoryEntity.Id,
                CategoryName = existingCategoryEntity.CategoryName,
                RangeFrom = existingCategoryEntity.RangeFrom,
                RangeTo = existingCategoryEntity.RangeTo,
                // Map other properties as needed
            };

            // Convert existing categories to CategoryDetailsDto
            var existingCategories = _ctx.Categories
                .Select(category => new CategoryDetailsDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    RangeFrom = category.RangeFrom,
                    RangeTo = category.RangeTo,
                    IconId = category.IconId,
                    Icon = category.Icon != null ? category.Icon.Path : null
                })
                .ToList();

            // Check if the updated category is valid
            var isValid = _categoryValidationService.IsCategoryValidForUpdate(existingCategories, request.UpdatedCategory, existingCategory);

            if (isValid)
            {
                // Update the existing Category entity
                existingCategoryEntity.CategoryName = request.UpdatedCategory.CategoryName;
                existingCategoryEntity.RangeFrom = request.UpdatedCategory.RangeFrom;
                existingCategoryEntity.RangeTo = request.UpdatedCategory.RangeTo; // Assign directly as decimal
                existingCategoryEntity.IconId = request.UpdatedCategory.IconId;
                // You may also update the IconId if needed

                await _ctx.SaveChangesAsync();

                // Map the updated Category entity to a CategoryDetailsDto
                var updatedCategoryDto = new CategoryDetailsDto
                {
                    CategoryId = existingCategoryEntity.Id,
                    CategoryName = existingCategoryEntity.CategoryName,
                    RangeFrom = existingCategoryEntity.RangeFrom,
                    RangeTo = existingCategoryEntity.RangeTo, // Assign directly as decimal
                    Icon = request.UpdatedCategory.Icon, // Assuming Icon is a string in CategoryDetailsDto
                    IconId = request.UpdatedCategory.IconId
                };

                return updatedCategoryDto;
            }

            // Handle the case where the category update is not valid (e.g., overlaps with existing)
            // You can return an appropriate response or throw an exception based on your needs

            return null; // Return null if the category update is not valid
        }

    }
}

