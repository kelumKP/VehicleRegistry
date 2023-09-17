using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdCommand, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;
        public GetCategoryByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<CategoryDetailsDto> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var categoryId = request.CategoryId;

            var query = from category in _ctx.Categories
                        join icon in _ctx.Icons on category.IconId equals icon.Id into iconGroup
                        where category.Id == categoryId
                        select new CategoryDetailsDto
                        {
                            Id = category.Id,
                            CategoryName = category.CategoryName,
                            RangeFrom = category.RangeFrom,
                            RangeTo = category.RangeTo,
                            Icon = iconGroup.FirstOrDefault() != null ? iconGroup.FirstOrDefault().Path : null
                        };

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
