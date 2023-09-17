using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail;
using VehicleRegistry.DAL;


namespace VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail
{
    public class DeleteVehicleDetailHandler : IRequestHandler<DeleteVehicleDetailCommand, bool>
    {
        private readonly DataContext _ctx;

        public DeleteVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Handle(DeleteVehicleDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find the vehicle detail with the specified VehicleDetailId
                var vehicleDetail = await _ctx.VehicleDetails.FindAsync(request.VehicleDetailId);

                if (vehicleDetail == null)
                {
                    // The vehicle detail with the specified ID was not found
                    return false;
                }

                // Remove the vehicle detail from the context and mark it for deletion
                _ctx.VehicleDetails.Remove(vehicleDetail);

                // Save changes to the database
                await _ctx.SaveChangesAsync();

                // Return true to indicate a successful delete operation
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the delete operation
                // You can log the exception or handle it based on your application's needs
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}