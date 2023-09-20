#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

namespace VehicleRegistry.Core.Models
{
    /// <summary>
    /// Represents an icon used in the Vehicle Registry application.
    /// </summary>
    public class Icon
    {
        /// <summary>
        /// Gets or sets the unique identifier for the icon.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the icon (optional).
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the file path to the icon (optional).
        /// </summary>
        public string? Path { get; set; }
    }
}

