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
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }
        public decimal Weight { get; set; }
        public string YearOfManufacture { get; set; }

    }
}
