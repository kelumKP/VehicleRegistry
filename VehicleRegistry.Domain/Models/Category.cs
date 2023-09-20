#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

namespace VehicleRegistry.Core.Models
{
    /// <summary>
    /// Represents a category for vehicles in the Vehicle Registry application.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the lower range value for the category (optional).
        /// </summary>
        public decimal? RangeFrom { get; set; }

        /// <summary>
        /// Gets or sets the upper range value for the category (optional).
        /// </summary>
        public decimal? RangeTo { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated icon for the category.
        /// </summary>
        public int IconId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to access the related Icon entity.
        /// </summary>
        public Icon Icon { get; set; }
    }
}
