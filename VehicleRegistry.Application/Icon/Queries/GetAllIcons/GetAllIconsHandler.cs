using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Icon.Queries.GetAllIcons
{
    public class GetAllIconsHandler : IRequestHandler<GetAllIconsQuery, List<IconDto>>
    {
        private readonly DataContext _ctx;
        public GetAllIconsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<IconDto>> Handle(GetAllIconsQuery request, CancellationToken cancellationToken)
        {
            var icons = await _ctx.Icons
                .Select(icon => new IconDto
                {
                    Id = icon.Id,
                    Name = icon.Name,
                    Icon = icon.Path
                    // Map other properties as needed
                })
                .ToListAsync();

            return icons;
        }
    }
}
