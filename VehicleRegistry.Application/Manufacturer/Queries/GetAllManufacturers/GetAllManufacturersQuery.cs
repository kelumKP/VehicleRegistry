#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers
{
    /// <summary>
    /// Represents a query to retrieve all manufacturers.
    /// </summary>
    public class GetAllManufacturersQuery : IRequest<List<ManufacturerDto>>
    {
    }
}

