using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail
{
    public class UpdateVehicleDetailCommand : IRequest<VehicleDetailDto>
    {
        public int VehicleDetailId { get; set; } // Id of the vehicle detail to update
        public VehicleDetailDto UpdatedVehicleDetail { get; set; } // Updated vehicle detail data
    }
}