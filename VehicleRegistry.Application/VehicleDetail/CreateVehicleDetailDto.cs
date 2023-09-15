using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail
{
    public class CreateVehicleDetailDto
    {
        public int VehicleDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public decimal Weight { get; set; }
        public string YearOfManufacture { get; set; }
    }
}
