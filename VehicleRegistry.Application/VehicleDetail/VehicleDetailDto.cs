#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Application.VehicleDetail
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for vehicle details used in the Vehicle Registry application.
    /// </summary>
    public class VehicleDetailDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle detail.
        /// </summary>
        public int VehicleDetailId { get; set; }

        /// <summary>
        /// Gets or sets the year of manufacture of the vehicle (must be between 1000 and 3000).
        /// </summary>
        [Required]
        [Range(1000, 3000, ErrorMessage = "Year of Manufacture must be between 1000 and 3000.")]
        public int YearOfManufacture { get; set; }

        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the owner.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer (optional).
        /// </summary>
        public string? NameOfManufacturer { get; set; }

        /// <summary>
        /// Gets or sets the icon associated with the vehicle (optional).
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets the weight of the vehicle.
        /// </summary>
        [Required]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the manufacturer for the vehicle.
        /// </summary>
        [Required]
        public int ManufacturerId { get; set; }
    }
}

