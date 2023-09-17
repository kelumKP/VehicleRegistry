using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Core.Models
{
    public class VehicleDetail
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public int OwnerId { get; set; }
        public decimal Weight { get; set; }
        public int YearOfManufacture { get; set; }

        // Add navigation properties
        public Manufacturer Manufacturer { get; set; }
        public Owner Owner { get; set; }

    }
}
