#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers
{
    /// <summary>
    /// Handler for retrieving all manufacturers.
    /// </summary>
    public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, List<ManufacturerDto>>
    {
        private readonly DataContext _ctx;

        public GetAllManufacturersHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve all manufacturers.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="ManufacturerDto"/> representing all manufacturers.</returns>
        public async Task<List<ManufacturerDto>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            // Use Select to project the Manufacturer entities into ManufacturerDto
            var manufacturerDtos = await _ctx.Manufacturers
                .Select(m => new ManufacturerDto
                {
                    // Map properties from the Manufacturer entity to the DTO
                    Id = m.Id,
                    NameOfManufacturer = m.NameOfManufacturer,
                    // Add other properties as needed
                })
                .ToListAsync();

            return manufacturerDtos;
        }
    }
}