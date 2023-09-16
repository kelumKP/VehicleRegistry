using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail
{
    public class CreateVehicleDetailCommand : IRequest<VehicleDetailDto>
    {
        public VehicleDetailDto NewVehicleDetail { get; set; }
    }
}
