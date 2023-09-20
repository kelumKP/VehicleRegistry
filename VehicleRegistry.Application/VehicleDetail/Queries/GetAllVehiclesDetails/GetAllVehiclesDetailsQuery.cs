#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail
{
    /// <summary>
    /// Represents a query to retrieve all vehicle details.
    /// </summary>
    public class GetAllVehiclesDetailsQuery : IRequest<List<VehicleDetailDto>>
    {
    }
}

