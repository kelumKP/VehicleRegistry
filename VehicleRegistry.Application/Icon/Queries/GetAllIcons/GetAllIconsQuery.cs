using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Icon.Queries.GetAllIcons
{
    public class GetAllIconsQuery : IRequest<List<Core.Models.Icon>>
    {
    }
}
