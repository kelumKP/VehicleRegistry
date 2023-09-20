#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail
{
    /// <summary>
    /// Handler for retrieving all vehicle details.
    /// </summary>
    public class GetAllVehiclesDetailsHandler : IRequestHandler<GetAllVehiclesDetailsQuery, List<VehicleDetailDto>>
    {
        private readonly DataContext _ctx;

        public GetAllVehiclesDetailsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve all vehicle details.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of <see cref="VehicleDetailDto"/> representing all vehicle details.</returns>
        public async Task<List<VehicleDetailDto>> Handle(GetAllVehiclesDetailsQuery request, CancellationToken cancellationToken)
        {
            var vehicleDetails = await _ctx.VehicleDetails
                .Include(vd => vd.Manufacturer)
                .Include(vd => vd.Owner)
                .Select(vd => new VehicleDetailDto
                {
                    VehicleDetailId = vd.Id,
                    YearOfManufacture = vd.YearOfManufacture,
                    FirstName = vd.Owner.FirstName,
                    LastName = vd.Owner.LastName,
                    NameOfManufacturer = vd.Manufacturer.NameOfManufacturer,
                    Weight = vd.Weight,
                    Icon = _ctx.Categories.FirstOrDefault(c => c.RangeFrom <= vd.Weight && (c.RangeTo == null || c.RangeTo >= vd.Weight)).Icon.Path
                })
                .ToListAsync();

            return vehicleDetails;
        }
    }
}
