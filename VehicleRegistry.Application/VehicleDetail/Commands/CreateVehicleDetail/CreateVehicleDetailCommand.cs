using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail
{
    public class CreateVehicleDetailCommand : IRequest<Core.Models.VehicleDetail>
    {
        public Core.Models.VehicleDetail VehicleDetail { get; set; }
    }
}
