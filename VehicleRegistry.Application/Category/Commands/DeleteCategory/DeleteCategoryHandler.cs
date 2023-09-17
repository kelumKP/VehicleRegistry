using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, List<CategoryDetailsDto>>
    {
        private readonly DataContext _ctx;

        public DeleteCategoryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<CategoryDetailsDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the category to be deleted from the database
            var categoryToDelete = await _ctx.Categories.FindAsync(request.CategoryId);

            if (categoryToDelete != null)
            {
                // Delete the category
                _ctx.Categories.Remove(categoryToDelete);
                await _ctx.SaveChangesAsync();

                // Rearrange the remaining categories
                var remainingCategories = _ctx.Categories.ToList(); // Fetch all remaining categories

                if (remainingCategories.Count > 0)
                {
                    // Sort the remaining categories by RangeFrom or RangeTo, depending on your use case
                    remainingCategories.Sort((c1, c2) =>
                    {
                        if (c1.RangeFrom.HasValue && c2.RangeFrom.HasValue)
                            return c1.RangeFrom.Value.CompareTo(c2.RangeFrom.Value);
                        if (c1.RangeTo.HasValue && c2.RangeTo.HasValue)
                            return c1.RangeTo.Value.CompareTo(c2.RangeTo.Value);
                        return 0;
                    });

                    // Update the RangeFrom and RangeTo values to fill gaps and cover all possible weights
                    for (int i = 0; i < remainingCategories.Count; i++)
                    {
                        var currentCategory = remainingCategories[i];

                        if (i == 0)
                        {
                            currentCategory.RangeFrom = 0; // Assuming the first category starts from 0
                        }
                        else
                        {
                            var previousCategory = remainingCategories[i - 1];
                            currentCategory.RangeFrom = previousCategory.RangeTo ?? 0; // Start from the previous category's RangeTo or 0 if null
                        }

                        // Update RangeTo
                        if (i == remainingCategories.Count - 1)
                        {
                            currentCategory.RangeTo = null; // Last category may have no upper bound
                        }
                        else
                        {
                            var nextCategory = remainingCategories[i + 1];
                            currentCategory.RangeTo = nextCategory.RangeFrom - 1; // Set RangeTo to cover the gap between categories
                        }
                    }

                    // Save changes to the database to persist the updated category ranges
                    await _ctx.SaveChangesAsync();
                }
            }

            // Return the updated list of categories (you may need to convert them to DTOs)
            var updatedCategories = _ctx.Categories
                .Select(category => new CategoryDetailsDto
                {
                    // Map properties accordingly
                })
                .ToList();

            return updatedCategories;
        }
    }
}