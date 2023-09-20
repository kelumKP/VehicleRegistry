#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Icon;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;

namespace VehicleRegistry.WebAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class IconController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IconController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all icons.
        /// </summary>
        /// <returns>A list of all icons.</returns>
        [HttpGet(Name = "GetAllIcons")]
        public async Task<IActionResult> GetAllIcons()
        {
            var result = await _mediator.Send(new GetAllIconsQuery());

            return Ok(result);
        }

        /// <summary>
        /// Create a new icon.
        /// </summary>
        /// <param name="icon">The icon details to create.</param>
        /// <returns>The created icon details.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateIcon([FromBody] IconDto icon)
        {
            var command = new CreateIconCommand() { NewIcon = icon };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
