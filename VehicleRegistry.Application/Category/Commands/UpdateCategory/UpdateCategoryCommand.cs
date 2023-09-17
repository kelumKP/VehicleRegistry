using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Commands.UpdateCategory
{
    namespace VehicleRegistry.Application.Category.Commands.UpdateCategory
    {
        public class UpdateCategoryCommand : IRequest<CategoryDetailsDto>
        {
            public CategoryDetailsDto UpdatedCategory { get; set; }
            public CategoryDetailsDto ExistingCategory { get; set; }
        }
    }
}
