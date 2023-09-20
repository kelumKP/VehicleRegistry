#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer
{
    /// <summary>
    /// Handler for creating a new manufacturer.
    /// </summary>
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, ManufacturerDto>
    {
        private readonly DataContext _ctx;

        public CreateManufacturerHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to create a new manufacturer.
        /// </summary>
        /// <param name="request">The command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="ManufacturerDto"/> representing the newly created manufacturer.</returns>
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

