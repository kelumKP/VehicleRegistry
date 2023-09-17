using MediatR;

namespace VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail
{
    public class DeleteVehicleDetailCommand : IRequest<bool>
    {
        public int VehicleDetailId { get; set; }
    }
}