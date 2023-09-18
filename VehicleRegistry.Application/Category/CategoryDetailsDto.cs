using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Helpers;

namespace VehicleRegistry.Application.Category
{
    public class CategoryDetailsDto
    {
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        [RangeFromLessThanRangeTo]
        public decimal? RangeFrom { get; set; }
        public decimal? RangeTo { get; set; }

        [Required]
        public int IconId { get; set; }
        public string? Icon { get; set; }
    }
}
