#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Category.Queries.GetCategoryById
{
    /// <summary>
    /// Represents a query to retrieve category details by ID.
    /// </summary>
    public class GetCategoryByIdQuery : IRequest<CategoryDetailsDto>
    {
        /// <summary>
        /// Gets or sets the identifier of the category to retrieve.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
