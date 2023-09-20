#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Category.Commands.UpdateCategory
{
    /// <summary>
    /// Represents a command to update a category.
    /// </summary>
    public class UpdateCategoryCommand : IRequest<CategoryDetailsDto>
    {
        /// <summary>
        /// Gets or sets the ID of the category to update.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the updated category data.
        /// </summary>
        public CategoryDetailsDto UpdatingCategory { get; set; }
    }
}

