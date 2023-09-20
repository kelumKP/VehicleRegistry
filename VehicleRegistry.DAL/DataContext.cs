#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using Microsoft.EntityFrameworkCore;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.DAL
{
    /// <summary>
    /// Represents the database context for the Vehicle Registry application.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{TContext}"/> to be used by the context.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region DbSet Properties

        /// <summary>
        /// Gets or sets the icons DbSet.
        /// </summary>
        public DbSet<Icon> Icons => Set<Icon>();

        /// <summary>
        /// Gets or sets the categories DbSet.
        /// </summary>
        public DbSet<Category> Categories => Set<Category>();

        /// <summary>
        /// Gets or sets the manufacturers DbSet.
        /// </summary>
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();

        /// <summary>
        /// Gets or sets the owners DbSet.
        /// </summary>
        public DbSet<Owner> Owners => Set<Owner>();

        /// <summary>
        /// Gets or sets the vehicle details DbSet.
        /// </summary>
        public DbSet<VehicleDetail> VehicleDetails => Set<VehicleDetail>();

        #endregion
    }
}
