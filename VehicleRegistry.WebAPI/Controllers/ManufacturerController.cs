#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of all manufacturers.</returns>
        [HttpGet(Name = "GetManufacturers")]
        public async Task<IActionResult> GetManufacturers()
        {
            var result = await _mediator.Send(new GetAllManufacturersQuery());

            return Ok(result);
        }

        /// <summary>
        /// Create a new manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer details to create.</param>
        /// <returns>The created manufacturer details.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromBody] Manufacturer manufacturer)
        {
            var command = new CreateManufacturerCommand() { NewManufacturer = manufacturer };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
