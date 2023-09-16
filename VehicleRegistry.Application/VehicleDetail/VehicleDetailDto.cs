using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail
{
    public class VehicleDetailDto
    {
        public int VehicleDetailId { get; set; }

        [Required]
        public string YearOfManufacture { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string? NameOfManufacturer { get; set; }
        public string? Icon { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public int ManufacturerId { get; set; }



    }
}
