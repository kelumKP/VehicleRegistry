using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail
{
    public class VehicleDetailDto
    {
        public int Id { get; set; }
        public string YearOfManufacture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOfManufacturer { get; set; }
        public string Path { get; set; }
        public string CategoryName { get; set; }
    }
}
