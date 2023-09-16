using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Core.Models
{
    public class Manufacturer
    {
        [Required]
        public int Id { get; set; }
        public string NameOfManufacturer { get; set; }

    }
}
