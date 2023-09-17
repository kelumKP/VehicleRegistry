using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdCommand : IRequest<CategoryDetailsDto>
    {
        public int CategoryId { get; set; }
    }
}
