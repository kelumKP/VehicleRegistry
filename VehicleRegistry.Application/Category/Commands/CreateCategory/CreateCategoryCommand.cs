#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
{
    /// <summary>
    /// Represents a command to create a new category.
    /// </summary>
    public class CreateCategoryCommand : IRequest<CategoryDetailsDto>
    {
        /// <summary>
        /// Gets or sets the details of the new category to create.
        /// </summary>
        public CategoryDetailsDto NewCategory { get; set; }
    }
}
