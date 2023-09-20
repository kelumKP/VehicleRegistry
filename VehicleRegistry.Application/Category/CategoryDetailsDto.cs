#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;
using VehicleRegistry.Application.Helpers;

namespace VehicleRegistry.Application.Category
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for category details.
    /// </summary>
    public class CategoryDetailsDto
    {
        /// <summary>
        /// Gets or sets the identifier of the category.
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the range from value for the category.
        /// </summary>
        [Required]
        [RangeFromLessThanRangeTo]
        public decimal? RangeFrom { get; set; }

        /// <summary>
        /// Gets or sets the range to value for the category.
        /// </summary>
        public decimal? RangeTo { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated icon.
        /// </summary>
        [Required]
        public int IconId { get; set; }

        /// <summary>
        /// Gets or sets the icon associated with the category.
        /// </summary>
        public string? Icon { get; set; }
    }
}