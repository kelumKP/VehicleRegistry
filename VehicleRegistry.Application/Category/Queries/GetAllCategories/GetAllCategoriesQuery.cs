using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<Core.Models.Category>>
    {
    }
}
