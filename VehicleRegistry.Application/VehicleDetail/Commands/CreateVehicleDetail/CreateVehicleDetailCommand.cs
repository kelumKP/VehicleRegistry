#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail
{
    /// <summary>
    /// Represents a command to create a new vehicle detail.
    /// </summary>
    public class CreateVehicleDetailCommand : IRequest<VehicleDetailDto>
    {
        /// <summary>
        /// Gets or sets the data for the new vehicle detail.
        /// </summary>
        public VehicleDetailDto NewVehicleDetail { get; set; }
    }
}
