using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail
{
    internal class CreateVehicleDetailHandler : IRequestHandler<CreateVehicleDetailCommand, Core.Models.VehicleDetail>
    {
        private readonly DataContext _ctx;
        public CreateVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Core.Models.VehicleDetail> Handle(CreateVehicleDetailCommand request, CancellationToken cancellationToken)
        {
            _ctx.VehicleDetails.Add(request.VehicleDetail);
            await _ctx.SaveChangesAsync();

            return request.VehicleDetail;
        }
    }
}
