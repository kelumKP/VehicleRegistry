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
    public class GetAllIconsHandler : IRequestHandler<GetAllIconsQuery, List<Core.Models.Icon>>
    {
        private readonly DataContext _ctx;
        public GetAllIconsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Core.Models.Icon>> Handle(GetAllIconsQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Icons.ToListAsync();
        }
    }
}
