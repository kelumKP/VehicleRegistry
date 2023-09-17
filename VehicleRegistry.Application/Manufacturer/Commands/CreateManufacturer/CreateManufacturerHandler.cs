using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer
{
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, ManufacturerDto>
    {
        private readonly DataContext _ctx;
        public CreateManufacturerHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<ManufacturerDto> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            // Create a new Manufacturer entity from the provided data
            var newManufacturer = new Core.Models.Manufacturer
            {
                // Map properties from request.NewManufacturer to the new entity
                NameOfManufacturer = request.NewManufacturer.NameOfManufacturer,
                // Add other properties as needed
            };

            // Add the new Manufacturer entity to the context
            _ctx.Manufacturers.Add(newManufacturer);

            // Save changes to the database to get the generated ManufacturerId
            await _ctx.SaveChangesAsync();

            // Create a ManufacturerDto from the newly created entity
            var manufacturerDto = new ManufacturerDto
            {
                Id = newManufacturer.Id,
                NameOfManufacturer = newManufacturer.NameOfManufacturer,
                // Map other properties as needed
            };

            return manufacturerDto;
        }
    }
}