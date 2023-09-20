#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById;
using VehicleRegistry.Core.Models;
using System.Threading.Tasks;

namespace VehicleRegistry.WebAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class VehicleDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a vehicle detail by its ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle detail to retrieve.</param>
        /// <returns>The vehicle detail with the specified ID.</returns>
        [HttpGet("{id}", Name = "GetVehicleDetailById")]
        public async Task<IActionResult> GetVehicleDetailById(int id)
        {
            var query = new GetVehicleDetailByIdQuery { VehicleDetailId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Vehicle detail not found.");
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all vehicle details.
        /// </summary>
        /// <returns>A list of all vehicle details.</returns>
        [HttpGet(Name = "GetVehiclesDetails")]
        public async Task<IActionResult> GetVehiclesDetails()
        {
            var result = await _mediator.Send(new GetAllVehiclesDetailsQuery());

            return Ok(result);
        }

        /// <summary>
        /// Create a new vehicle detail.
        /// </summary>
        /// <param name="vehicleDetailDto">The vehicle detail to create.</param>
        /// <returns>The created vehicle detail.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateVehicleDetail([FromBody] VehicleDetailDto vehicleDetailDto)
        {
            var command = new CreateVehicleDetailCommand() { NewVehicleDetail = vehicleDetailDto };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Update a vehicle detail by its ID.
        /// </summary>
        /// <param name="VehicleDetailId">The ID of the vehicle detail to update.</param>
        /// <param name="updatedVehicleDetailDto">The updated vehicle detail data.</param>
        /// <returns>The updated vehicle detail.</returns>
        [HttpPut("{VehicleDetailId}")]
        public async Task<IActionResult> UpdateVehicleDetail(int VehicleDetailId, [FromBody] VehicleDetailDto updatedVehicleDetailDto)
        {
            var command = new UpdateVehicleDetailCommand
            {
                VehicleDetailId = VehicleDetailId,
                UpdatedVehicleDetail = updatedVehicleDetailDto
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Vehicle detail not found.");
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a vehicle detail by its ID.
        /// </summary>
        /// <param name="VehicleDetailId">The ID of the vehicle detail to delete.</param>
        /// <returns>No content if the delete operation was successful; otherwise, a not found response.</returns>
        [HttpDelete("{VehicleDetailId}")]
        public async Task<IActionResult> DeleteVehicleDetail(int VehicleDetailId)
        {
            var command = new DeleteVehicleDetailCommand
            {
                VehicleDetailId = VehicleDetailId
            };

            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent(); // HTTP 204 No Content
            }
            else
            {
                return NotFound("Vehicle detail not found.");
            }
        }
    }
}
