using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer
{
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, Core.Models.Manufacturer>
    {
        private readonly DataContext _ctx;
        public CreateManufacturerHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Core.Models.Manufacturer> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            _ctx.Manufacturers.Add(request.NewManufacturer);
            await _ctx.SaveChangesAsync();

            return request.NewManufacturer;
        }
    }
}