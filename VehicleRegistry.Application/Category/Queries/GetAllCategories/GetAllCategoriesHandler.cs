#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Queries.GetAllCategories
{
    /// <summary>
    /// Handler for retrieving all category details.
    /// </summary>
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDetailsDto>>
    {
        private readonly DataContext _ctx;

        public GetAllCategoriesHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve all category details.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="CategoryDetailsDto"/> representing all category details.</returns>
        public async Task<List<CategoryDetailsDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = from category in _ctx.Categories
                        join icon in _ctx.Icons on category.IconId equals icon.Id into iconGroup
                        orderby category.RangeFrom
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
