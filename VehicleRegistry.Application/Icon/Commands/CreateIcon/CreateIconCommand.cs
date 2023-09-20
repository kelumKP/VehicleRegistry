#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Icon.Commands.CreateIcon
{
    /// <summary>
    /// Represents a command to create a new icon.
    /// </summary>
    public class CreateIconCommand : IRequest<IconDto>
    {
        /// <summary>
        /// Gets or sets the data for the new icon.
        /// </summary>
        public IconDto NewIcon { get; set; }
    }
}
