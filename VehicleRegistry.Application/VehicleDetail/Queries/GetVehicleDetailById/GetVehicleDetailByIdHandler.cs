#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById
{
    /// <summary>
    /// Handler for retrieving a vehicle detail by its identifier.
    /// </summary>
    public class GetVehicleDetailByIdHandler : IRequestHandler<GetVehicleDetailByIdQuery, VehicleDetailDto>
    {
        private readonly DataContext _ctx;

        public GetVehicleDetailByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the query to retrieve a vehicle detail by its identifier.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="VehicleDetailDto"/> representing the retrieved vehicle detail.</returns>
        public async Task<VehicleDetailDto> Handle(GetVehicleDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleDetail = await _ctx.VehicleDetails
                .Include(vd => vd.Manufacturer)
                .Include(vd => vd.Owner)
                .FirstOrDefaultAsync(vd => vd.Id == request.VehicleDetailId);

            if (vehicleDetail == null)
            {
                // Return null or throw an exception to handle not found scenarios
                return null;
            }

            return new VehicleDetailDto
            {
                VehicleDetailId = vehicleDetail.Id,
                YearOfManufacture = vehicleDetail.YearOfManufacture,
                FirstName = vehicleDetail.Owner.FirstName,
                LastName = vehicleDetail.Owner.LastName,
                ManufacturerId = vehicleDetail.Manufacturer.Id,
                NameOfManufacturer = vehicleDetail.Manufacturer.NameOfManufacturer,
                Weight = vehicleDetail.Weight,
                Icon = vehicleDetail.Weight != null
                    ? _ctx.Categories.FirstOrDefault(c => c.RangeFrom <= vehicleDetail.Weight && (c.RangeTo == null || c.RangeTo >= vehicleDetail.Weight))?.Icon?.Path
                    : null
            };
        }
    }
}
