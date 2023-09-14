using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail
{
    public class GetAllVehiclesDetailsHandler : IRequestHandler<GetAllVehiclesDetailsQuery, List<Core.Models.VehicleDetail>>
    {
        private readonly DataContext _ctx;
        public GetAllVehiclesDetailsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Core.Models.VehicleDetail>> Handle(GetAllVehiclesDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.VehicleDetails.ToListAsync();
        }
    }
}
