using MediatR;
using Microsoft.EntityFrameworkCore;
#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Queries.GetCategoryById
{
    /// <summary>
    /// Handler for retrieving category details by ID.
    /// </summary>
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsDto>
    {
        private readonly DataContext _ctx;

        public GetCategoryByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve category details by ID.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="CategoryDetailsDto"/> representing the category details.</returns>
        public async Task<CategoryDetailsDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryId = request.CategoryId;

            var query = from category in _ctx.Categories
                        join icon in _ctx.Icons on category.IconId equals icon.Id into iconGroup
                        where category.Id == categoryId
                        select new CategoryDetailsDto
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName,
                            RangeFrom = category.RangeFrom,
                            RangeTo = category.RangeTo,
                            IconId = category.IconId,
                            Icon = iconGroup.FirstOrDefault() != null ? iconGroup.FirstOrDefault().Path : null
                        };

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
