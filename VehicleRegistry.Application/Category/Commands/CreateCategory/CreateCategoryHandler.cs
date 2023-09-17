using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.DAL;
using VehicleRegistry.Core.Models;
using VehicleRegistry.Application.Category.Services;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
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
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    RangeFrom = category.RangeFrom,
                    RangeTo = category.RangeTo,
                    Icon = category.Icon != null ? category.Icon.Path : null
                })
                .ToList();

            // Check if the new category is valid
            var isValid = _categoryValidationService.IsCategoryValidForUpdate(existingCategories, request.NewCategory, null);

            if (isValid)
            {
                // Create a new Category entity from the CategoryDetailsDto
                var newCategory = new Core.Models.Category
                {
                    CategoryName = request.NewCategory.CategoryName,
                    RangeFrom = request.NewCategory.RangeFrom,
                    RangeTo = request.NewCategory.RangeTo, // Assign directly as decimal
                    IconId = 1 // Set the IconId as needed
                };

                _ctx.Categories.Add(newCategory);
                await _ctx.SaveChangesAsync();

                // Map the Category entity to a CategoryDetailsDto
                var categoryDto = new CategoryDetailsDto
                {
                    Id = newCategory.Id,
                    CategoryName = newCategory.CategoryName,
                    RangeFrom = newCategory.RangeFrom,
                    RangeTo = newCategory.RangeTo, // Assign directly as decimal
                    Icon = request.NewCategory.Icon  // Assuming Icon is a string in CategoryDetailsDto
                };

                return categoryDto;
            }

            // Handle the case where the category is not valid (e.g., overlaps with existing)
            // You can return an appropriate response or throw an exception based on your needs

            return null; // Return null if the category is not valid
        }
    }
}
