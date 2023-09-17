using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById
{
    public class GetVehicleDetailByIdHandler : IRequestHandler<GetVehicleDetailByIdQuery, VehicleDetailDto>
    {
        private readonly DataContext _ctx;

        public GetVehicleDetailByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<VehicleDetailDto> Handle(GetVehicleDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleDetail = await _ctx.VehicleDetails
                .Include(vd => vd.Manufacturer)
                .Include(vd => vd.Owner)
                .FirstOrDefaultAsync(vd => vd.Id == request.VehicleDetailId);

            if (vehicleDetail == null)
            {
                // Return null or throw an exception to handle not found scenarios
                return null;
            }

            return new VehicleDetailDto
            {
                VehicleDetailId = vehicleDetail.Id,
                YearOfManufacture = vehicleDetail.YearOfManufacture,
                FirstName = vehicleDetail.Owner.FirstName,
                LastName = vehicleDetail.Owner.LastName,
                ManufacturerId = vehicleDetail.Manufacturer.Id,
                NameOfManufacturer = vehicleDetail.Manufacturer.NameOfManufacturer,
                Weight = vehicleDetail.Weight,
                Icon = vehicleDetail.Weight != null
    ? _ctx.Categories.FirstOrDefault(c => c.RangeFrom <= vehicleDetail.Weight && (c.RangeTo == null || c.RangeTo >= vehicleDetail.Weight))?.Icon?.Path
    : null
            };
        }
    }
}
