using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers
{
    public class GetAllManufacturersQuery : IRequest<List<Core.Models.Manufacturer>>
    {
    }
}
