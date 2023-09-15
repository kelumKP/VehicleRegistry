using MediatR;
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
    internal class CreateVehicleDetailHandler : IRequestHandler<CreateVehicleDetailCommand, CreateVehicleDetailDto>
    {
        private readonly DataContext _ctx;
        public CreateVehicleDetailHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<CreateVehicleDetailDto> Handle(CreateVehicleDetailCommand request, CancellationToken cancellationToken)
        {
            // Create a new Owner entity from the provided FirstName
            var owner = new Owner
            {
                FirstName = request.NewVehicleDetail.FirstName,
                LastName = request.NewVehicleDetail.LastName
            };

            // Add the Owner entity to the context
            _ctx.Owners.Add(owner);

            // Save changes to the database to get the generated OwnerId
            await _ctx.SaveChangesAsync();

            // Create a new VehicleDetail entity
            var vehicleDetail = new Core.Models.VehicleDetail
            {
                ManufacturerId = request.NewVehicleDetail.ManufacturerId,
                CategoryId = request.NewVehicleDetail.CategoryId,
                OwnerId = owner.Id, // Assign the created owner's ID
                Weight = request.NewVehicleDetail.Weight,
                YearOfManufacture = request.NewVehicleDetail.YearOfManufacture
            };

            // Add the VehicleDetail entity to the context
            _ctx.VehicleDetails.Add(vehicleDetail);

            // Save changes to the database
            await _ctx.SaveChangesAsync();

            // Create a response DTO with the details of the newly created VehicleDetail
            var responseDto = new CreateVehicleDetailDto
            {
                VehicleDetailId = vehicleDetail.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ManufacturerId = vehicleDetail.ManufacturerId,
                CategoryId = vehicleDetail.CategoryId,
                Weight = vehicleDetail.Weight,
                YearOfManufacture = vehicleDetail.YearOfManufacture
            };

            return responseDto;
        }
    }
}
