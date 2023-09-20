#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail
{
    /// <summary>
    /// Represents a command to delete a vehicle detail by its identifier.
    /// </summary>
    public class DeleteVehicleDetailCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the identifier of the vehicle detail to delete.
        /// </summary>
        public int VehicleDetailId { get; set; }
    }
}