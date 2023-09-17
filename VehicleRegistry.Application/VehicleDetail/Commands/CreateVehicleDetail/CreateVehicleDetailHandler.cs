using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.Core.Models;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail
{
    internal class CreateVehicleDetailHandler : IRequestHandler<CreateVehicleDetailCommand, VehicleDetailDto>
    {
        private readonly DataContext _ctx;
        public CreateVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<VehicleDetailDto> Handle(CreateVehicleDetailCommand request, CancellationToken cancellationToken)
        {
            // Check if an owner with the given FirstName and LastName exists
            var existingOwner = await _ctx.Owners
                .FirstOrDefaultAsync(o =>
                    o.FirstName.ToLower() == request.NewVehicleDetail.FirstName.ToLower() &&
                    o.LastName.ToLower() == request.NewVehicleDetail.LastName.ToLower());

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
                    FirstName = request.NewVehicleDetail.FirstName,
                    LastName = request.NewVehicleDetail.LastName
                };

                _ctx.Owners.Add(newOwner);
                await _ctx.SaveChangesAsync();

                ownerId = newOwner.Id;
            }

            // Create a new VehicleDetail entity
            var vehicleDetail = new Core.Models.VehicleDetail
            {
                ManufacturerId = request.NewVehicleDetail.ManufacturerId,
                OwnerId = ownerId, // Set the OwnerId with the retrieved or newly created owner's Id
                Weight = request.NewVehicleDetail.Weight,
                YearOfManufacture = request.NewVehicleDetail.YearOfManufacture
            };

            // Add the VehicleDetail entity to the context
            _ctx.VehicleDetails.Add(vehicleDetail);

            // Save changes to the database
            await _ctx.SaveChangesAsync();

            // Create a response DTO with the details of the newly created VehicleDetail
            var responseDto = new VehicleDetailDto
            {
                VehicleDetailId = vehicleDetail.Id,
                FirstName = request.NewVehicleDetail.FirstName,
                LastName = request.NewVehicleDetail.LastName,
                ManufacturerId = vehicleDetail.ManufacturerId,
                Weight = vehicleDetail.Weight,
                YearOfManufacture = vehicleDetail.YearOfManufacture
            };

            return responseDto;
        }
    }
}
