#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.Core.Models;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail
{
    /// <summary>
    /// Handler for updating a vehicle detail.
    /// </summary>
    internal class UpdateVehicleDetailHandler : IRequestHandler<UpdateVehicleDetailCommand, VehicleDetailDto>
    {
        private readonly DataContext _ctx;

        public UpdateVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to update a vehicle detail.
        /// </summary>
        /// <param name="request">The command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="VehicleDetailDto"/> representing the updated vehicle detail.</returns>
        public async Task<VehicleDetailDto> Handle(UpdateVehicleDetailCommand request, CancellationToken cancellationToken)
        {
            // Find the existing VehicleDetail entity by its Id
            var existingVehicleDetail = await _ctx.VehicleDetails.FindAsync(request.VehicleDetailId);

            if (existingVehicleDetail == null)
            {
                // Handle the case where the vehicle detail with the specified Id was not found
                // You can throw an exception or return an appropriate response
                // For simplicity, we'll return null in this example
                return null;
            }

            // Check if an owner with the given FirstName and LastName exists
            var existingOwner = await _ctx.Owners
                .FirstOrDefaultAsync(o =>
                    o.FirstName.ToLower() == request.UpdatedVehicleDetail.FirstName.ToLower() &&
                    o.LastName.ToLower() == request.UpdatedVehicleDetail.LastName.ToLower());

            int ownerId;

            if (existingOwner != null)
            {
                // Owner with the same FirstName and LastName exists, use the existing owner's Id
                ownerId = existingOwner.Id;
            }
            else
            {
                // Owner does not exist, create a new owner and get the Id
                var newOwner = new Owner
                {
                    FirstName = request.UpdatedVehicleDetail.FirstName,
                    LastName = request.UpdatedVehicleDetail.LastName
                };

                _ctx.Owners.Add(newOwner);
                await _ctx.SaveChangesAsync();

                ownerId = newOwner.Id;
            }

            // Update the properties of the existing VehicleDetail entity with the new data
            existingVehicleDetail.ManufacturerId = request.UpdatedVehicleDetail.ManufacturerId;
            existingVehicleDetail.Weight = request.UpdatedVehicleDetail.Weight;
            existingVehicleDetail.YearOfManufacture = request.UpdatedVehicleDetail.YearOfManufacture;
            existingVehicleDetail.OwnerId = ownerId; // Set the OwnerId with the retrieved or newly created owner's Id

            // Save changes to the database
            await _ctx.SaveChangesAsync();

            // Create a response DTO with the details of the updated VehicleDetail
            var responseDto = new VehicleDetailDto
            {
                VehicleDetailId = existingVehicleDetail.Id,
                FirstName = request.UpdatedVehicleDetail.FirstName,
                LastName = request.UpdatedVehicleDetail.LastName,
                ManufacturerId = existingVehicleDetail.ManufacturerId,
                Weight = existingVehicleDetail.Weight,
                YearOfManufacture = existingVehicleDetail.YearOfManufacture
            };

            return responseDto;
        }
    }
}