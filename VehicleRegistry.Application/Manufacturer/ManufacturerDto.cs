#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Application.Manufacturer
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for a manufacturer.
    /// </summary>
    public class ManufacturerDto
    {
        /// <summary>
        /// Gets or sets the identifier of the manufacturer.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer.
        /// </summary>
        public string NameOfManufacturer { get; set; }
    }
}
