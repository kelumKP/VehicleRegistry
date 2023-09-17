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
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDetailsDto>>
    {
        private readonly DataContext _ctx;
        public GetAllCategoriesHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<CategoryDetailsDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = from category in _ctx.Categories
                        join icon in _ctx.Icons on category.IconId equals icon.Id into iconGroup
                        select new CategoryDetailsDto
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName,
                            RangeFrom = category.RangeFrom,
                            RangeTo = category.RangeTo,
                            IconId = category.IconId,
                            Icon = iconGroup.FirstOrDefault() != null ? iconGroup.FirstOrDefault().Path : null // Check for null and then access Path
                        };

            return await query.ToListAsync(cancellationToken);
        }
    }
}
