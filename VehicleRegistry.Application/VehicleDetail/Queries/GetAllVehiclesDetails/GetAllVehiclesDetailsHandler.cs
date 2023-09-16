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
    public class GetAllVehiclesDetailsHandler : IRequestHandler<GetAllVehiclesDetailsQuery, List<VehicleDetailDto>>
    {
        private readonly DataContext _ctx;
        public GetAllVehiclesDetailsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<VehicleDetailDto>> Handle(GetAllVehiclesDetailsQuery request, CancellationToken cancellationToken)
        {
            var vehicleDetails = await _ctx.VehicleDetails
                .Include(vd => vd.Manufacturer)
                .Include(vd => vd.Category)
                .Include(vd => vd.Owner)
                .Include(vd => vd.Category.Icon) // Include Icon from Category
                .Select(vd => new VehicleDetailDto
                {
                    VehicleDetailId = vd.Id,
                    YearOfManufacture = vd.YearOfManufacture,
                    FirstName = vd.Owner.FirstName,
                    LastName = vd.Owner.LastName,
                    NameOfManufacturer = vd.Manufacturer.NameOfManufacturer,
                    Icon = vd.Category.Icon.Path,
                    Weight = vd.Weight
                })
                .ToListAsync();

            return vehicleDetails;

        }
    }
}
