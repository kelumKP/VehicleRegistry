using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers
{
    public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, List<ManufacturerDto>>
    {
        private readonly DataContext _ctx;
        public GetAllManufacturersHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
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
