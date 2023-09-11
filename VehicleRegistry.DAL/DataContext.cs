using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Icon> Icons => Set<Icon>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Manufacturer> Manufacturerers => Set<Manufacturer>();
        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<VehicleDetail> VehicleDetails => Set<VehicleDetail>();


    }
}
