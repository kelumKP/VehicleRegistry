#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById
{
    /// <summary>
    /// Represents a query to retrieve a vehicle detail by its identifier.
    /// </summary>
    public class GetVehicleDetailByIdQuery : IRequest<VehicleDetailDto>
    {
        /// <summary>
        /// Gets or sets the identifier of the vehicle detail to retrieve.
        /// </summary>
        public int VehicleDetailId { get; set; }
    }
}
