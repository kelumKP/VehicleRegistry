#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer
{
    /// <summary>
    /// Represents a command to create a new manufacturer.
    /// </summary>
    public class CreateManufacturerCommand : IRequest<ManufacturerDto>
    {
        /// <summary>
        /// Gets or sets the data for the new manufacturer.
        /// </summary>
        public Core.Models.Manufacturer NewManufacturer { get; set; }
    }
}
