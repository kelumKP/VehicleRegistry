using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers;
using VehicleRegistry.Application.VehicleDetail.Commands.CreateVehicleDetail;
using VehicleRegistry.Application.VehicleDetail.Queries.GetAllVehiclesDetail;
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

        [HttpGet(Name = "GetVehiclesDetails")]
        public async Task<IActionResult> GetVehiclesDetails()
        {
            var result = await _mediator.Send(new GetAllVehiclesDetailsQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleDetail([FromBody] VehicleDetail vehicleDetail)
        {
            var command = new CreateVehicleDetailCommand() { VehicleDetail = vehicleDetail };

            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
