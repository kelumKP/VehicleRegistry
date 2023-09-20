#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Application.Icon
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an icon.
    /// </summary>
    public class IconDto
    {
        /// <summary>
        /// Gets or sets the identifier of the icon.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the icon.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the icon path or content.
        /// </summary>
        public string? Icon { get; set; }
    }
}
