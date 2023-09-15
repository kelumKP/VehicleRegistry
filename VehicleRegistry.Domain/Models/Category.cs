using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public int IconId { get; set; }

        // Add navigation property to access related Icon entity
        public Icon Icon { get; set; }

    }
}
