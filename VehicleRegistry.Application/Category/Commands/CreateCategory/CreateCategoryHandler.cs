using MediatR;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Services;
using VehicleRegistry.Application.Category;
using VehicleRegistry.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Application.Category.Commands.DeleteCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;
        private readonly ICategoryValidationService _categoryValidationService;

        public CreateCategoryHandler(DataContext ctx, ICategoryValidationService categoryValidationService)
        {
            _ctx = ctx;
            _categoryValidationService = categoryValidationService;
        }

        public async Task<CategoryDetailsDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Convert existing categories to CategoryDetailsDto
            var existingCategories = _ctx.Categories
                .Select(category => new CategoryDetailsDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    RangeFrom = category.RangeFrom,
                    RangeTo = category.RangeTo,
                    Icon = category.Icon != null ? category.Icon.Path : null
                })
                .ToList();

            // Find the maximum RangeTo value among existing categories
            decimal? maxRangeTo = existingCategories.Max(c => c.RangeTo);

            // Calculate the new RangeFrom value
            decimal newRangeFrom = maxRangeTo != null ? maxRangeTo.Value + 0.01m : 0.01m;

            // Check if the new category is valid
            var isValid = _categoryValidationService.IsCategoryValidForInsert(existingCategories, request.NewCategory);

            if (isValid)
            {
                // Create a new Category entity from the CategoryDetailsDto
                var newCategory = new Core.Models.Category
                {
                    CategoryName = request.NewCategory.CategoryName,
                    RangeFrom = newRangeFrom,
                    RangeTo = request.NewCategory.RangeTo,
                    IconId = 1 // Set the IconId as needed
                };

                // Update RangeTo for the next category, if it exists
                var nextCategory = existingCategories
                    .Where(c => c.RangeFrom > newCategory.RangeTo)
                    .OrderBy(c => c.RangeFrom)
                    .FirstOrDefault();

                if (nextCategory != null)
                {
                    newCategory.RangeTo = nextCategory.RangeFrom - 0.01m;
                }
                else
                {
                    // If there's no next category, set RangeTo to NULL
                    newCategory.RangeTo = null;
                }

                _ctx.Categories.Add(newCategory);
                await _ctx.SaveChangesAsync();

                // Map the Category entity to a CategoryDetailsDto
                var categoryDto = new CategoryDetailsDto
                {
                    CategoryId = newCategory.Id,
                    CategoryName = newCategory.CategoryName,
                    RangeFrom = newCategory.RangeFrom,
                    RangeTo = newCategory.RangeTo,
                    Icon = request.NewCategory.Icon // Assuming Icon is a string in CategoryDetailsDto
                };

                return categoryDto;
            }

            // Handle the case where the category is not valid (e.g., overlaps with existing)
            // You can return an appropriate response or throw an exception based on your needs

            return null; // Return null if the category is not valid
        }
    }


}


