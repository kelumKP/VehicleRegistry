#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Icon.Queries.GetAllIcons
{
    /// <summary>
    /// Handler for retrieving all icons.
    /// </summary>
    public class GetAllIconsHandler : IRequestHandler<GetAllIconsQuery, List<IconDto>>
    {
        private readonly DataContext _ctx;

        public GetAllIconsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve all icons.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="IconDto"/> representing all icons.</returns>
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
