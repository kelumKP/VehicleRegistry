#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Category.Commands.DeleteCategory
{
    /// <summary>
    /// Represents a command to delete a category.
    /// </summary>
    public class DeleteCategoryCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the ID of the category to delete.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
