
#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

namespace VehicleRegistry.Core.Models
{
    /// <summary>
    /// Represents detailed information about a vehicle in the Vehicle Registry application.
    /// </summary>
    public class VehicleDetail
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle detail.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the manufacturer for the vehicle.
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the owner of the vehicle.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the weight of the vehicle.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the year of manufacture of the vehicle.
        /// </summary>
        public int YearOfManufacture { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to access the related Manufacturer entity.
        /// </summary>
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to access the related Owner entity.
        /// </summary>
        public Owner Owner { get; set; }
    }
}