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

            // Find the category where the weight falls within the range
            var category = await _ctx.Categories
                .FirstOrDefaultAsync(c => request.NewVehicleDetail.Weight >= c.RangeFrom && request.NewVehicleDetail.Weight <= c.RangeTo);

            // Create a new VehicleDetail entity
            var vehicleDetail = new Core.Models.VehicleDetail
            {
                ManufacturerId = request.NewVehicleDetail.ManufacturerId,
                CategoryId = category.Id,
                OwnerId = owner.Id, // Assign the created owner's ID
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
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                ManufacturerId = vehicleDetail.ManufacturerId,
                Weight = vehicleDetail.Weight,
                YearOfManufacture = vehicleDetail.YearOfManufacture
            };

            return responseDto;
        }
    }
}
