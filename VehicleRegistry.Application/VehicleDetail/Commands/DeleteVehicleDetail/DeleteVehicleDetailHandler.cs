#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail
{
    /// <summary>
    /// Handler for deleting a vehicle detail.
    /// </summary>
    public class DeleteVehicleDetailHandler : IRequestHandler<DeleteVehicleDetailCommand, bool>
    {
        private readonly DataContext _ctx;

        public DeleteVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to delete a vehicle detail by its identifier.
        /// </summary>
        /// <param name="request">The command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the delete operation is successful; otherwise, false.</returns>
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