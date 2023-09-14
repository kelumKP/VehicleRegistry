using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers
{
    public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, List<Core.Models.Manufacturer>>
    {
        private readonly DataContext _ctx;
        public GetAllManufacturersHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Core.Models.Manufacturer>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Manufacturers.ToListAsync();
        }
    }
}
