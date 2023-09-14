using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer;
using VehicleRegistry.Application.Manufacturer.Queries.GetAllManufacturers;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.WebAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManufacturerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetManufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            var result = await _mediator.Send(new GetAllManufacturersQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromBody] Manufacturer manufacturer)
        {
            var command = new CreateManufacturerCommand() { NewManufacturer = manufacturer };

            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
