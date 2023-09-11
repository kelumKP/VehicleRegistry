using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand  : IRequest<Core.Models.Category>
    {
        public Core.Models.Category NewCategory {  get; set; }
    }
}
