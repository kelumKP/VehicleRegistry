#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Commands.DeleteCategory
{
    /// <summary>
    /// Represents a handler for deleting a category.
    /// </summary>
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly DataContext _ctx;

        public DeleteCategoryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the deletion of a category.
        /// </summary>
        /// <param name="request">The delete category command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the category was successfully deleted; otherwise, false.</returns>
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the category to be deleted from the database
            var categoryToDelete = await _ctx.Categories.FindAsync(request.CategoryId);

            // Rearrange the remaining categories
            var beforeDeleteCategories = await _ctx.Categories.ToListAsync();

            if (categoryToDelete != null && beforeDeleteCategories.Count > 1)
            {
                // Delete the category
                _ctx.Categories.Remove(categoryToDelete);
                await _ctx.SaveChangesAsync();

                // Rearrange the remaining categories
                var remainingCategories = await _ctx.Categories.ToListAsync(); // Fetch all remaining categories

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
                            currentCategory.RangeFrom = 0.01m; // Set the lowest RangeFrom value
                        }
                        else
                        {
                            var previousCategory = remainingCategories[i - 1];
                            currentCategory.RangeFrom = previousCategory.RangeTo.GetValueOrDefault(0) + 0.01m; // Start from the previous category's RangeTo or 0 if null
                        }

                        // Update RangeTo
                        if (i == remainingCategories.Count - 1)
                        {
                            currentCategory.RangeTo = null; // Set the maximum RangeTo value to NULL for the last category
                        }
                        else
                        {
                            var nextCategory = remainingCategories[i + 1];
                            currentCategory.RangeTo = nextCategory.RangeFrom - 0.01m; // Set RangeTo to cover the gap between categories
                        }
                    }

                    // Save changes to the database to persist the updated category ranges
                    await _ctx.SaveChangesAsync();
                }

                return true; // Return true to indicate successful deletion
            }

            // Return false to indicate that the category was not found and nothing was deleted
            return false;
        }
    }
}
