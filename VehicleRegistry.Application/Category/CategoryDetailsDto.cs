using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category
{
    public class CategoryDetailsDto
    {
        [Required]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal? RangeFrom { get; set; }
        public decimal? RangeTo { get; set; }
        public string? Icon { get; set; }
    }
}
