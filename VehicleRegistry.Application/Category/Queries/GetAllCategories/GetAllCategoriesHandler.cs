using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Core.Models.Category>>
    {
        private readonly DataContext _ctx;
        public GetAllCategoriesHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Core.Models.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Categories.ToListAsync();
        }
    }
}
