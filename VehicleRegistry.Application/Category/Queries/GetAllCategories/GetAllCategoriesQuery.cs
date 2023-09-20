#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Category.Queries.GetAllCategories
{
    /// <summary>
    /// Represents a query to retrieve all category details.
    /// </summary>
    public class GetAllCategoriesQuery : IRequest<List<CategoryDetailsDto>>
    {
    }
}

