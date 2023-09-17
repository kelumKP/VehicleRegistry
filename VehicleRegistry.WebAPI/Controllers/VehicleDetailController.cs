using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers;
using VehicleRegistry.Application.VehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.DeleteVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Commands.UpdateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetVehicleDetailById;
using VehicleRegistry.Core.Models;

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

        [HttpGet(Name = "GetVehiclesDetails")]
        public async Task<IActionResult> GetVehiclesDetails()
        {
            var result = await _mediator.Send(new GetAllVehiclesDetailsQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleDetail([FromBody] VehicleDetailDto vehicleDetailDto)
        {
            var command = new CreateVehicleDetailCommand() { NewVehicleDetail = vehicleDetailDto };

            var result = await _mediator.Send(command);

            return Ok(result);

        }

        [HttpPut("{VehicleDetailId}")]
        public async Task<IActionResult> UpdateVehicleDetail(int VehicleDetailId, [FromBody] VehicleDetailDto updatedVehicleDetailDto)
        {
            // Create an instance of UpdateVehicleDetailCommand
            var command = new UpdateVehicleDetailCommand
            {
                VehicleDetailId = VehicleDetailId,
                UpdatedVehicleDetail = updatedVehicleDetailDto
            };

            // Send the command to the corresponding handler
            var result = await _mediator.Send(command);

            if (result == null)
            {
                // Handle the case where the vehicle detail with the specified Id was not found
                // You can return a NotFound response or an appropriate error message
                return NotFound("Vehicle detail not found.");
            }

            // Return the updated vehicle detail in the response
            return Ok(result);
        }

        [HttpDelete("{VehicleDetailId}")]
        public async Task<IActionResult> DeleteVehicleDetail(int VehicleDetailId)
        {
            // Create an instance of DeleteVehicleDetailCommand
            var command = new DeleteVehicleDetailCommand
            {
                VehicleDetailId = VehicleDetailId
            };

            // Send the command to the corresponding handler
            var result = await _mediator.Send(command);

            if (result)
            {
                // Return a successful response if the delete operation was successful
                return NoContent(); // HTTP 204 No Content
            }
            else
            {
                // Handle the case where the vehicle detail with the specified Id was not found
                // You can return a NotFound response or an appropriate error message
                return NotFound("Vehicle detail not found.");
            }
        }
    }
}
