#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Core.Models
{
    /// <summary>
    /// Represents a manufacturer of vehicles in the Vehicle Registry application.
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the manufacturer.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer.
        /// </summary>
        public string NameOfManufacturer { get; set; }
    }
}

