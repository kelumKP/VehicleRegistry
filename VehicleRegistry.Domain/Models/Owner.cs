#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

namespace VehicleRegistry.Core.Models
{
    /// <summary>
    /// Represents an owner of a vehicle in the Vehicle Registry application.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Gets or sets the unique identifier for the owner.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the owner.
        /// </summary>
        public string LastName { get; set; }
    }
}
