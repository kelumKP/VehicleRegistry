#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail
{
    /// <summary>
    /// Represents a command to update a vehicle detail.
    /// </summary>
    public class UpdateVehicleDetailCommand : IRequest<VehicleDetailDto>
    {
        /// <summary>
        /// Gets or sets the identifier of the vehicle detail to update.
        /// </summary>
        public int VehicleDetailId { get; set; }

        /// <summary>
        /// Gets or sets the updated vehicle detail data.
        /// </summary>
        public VehicleDetailDto UpdatedVehicleDetail { get; set; }
    }
}
