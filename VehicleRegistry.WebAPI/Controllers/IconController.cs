using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.Application.Icon.Commands.CreateIcon;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.Core.Models;

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

        [HttpGet(Name = "GetAllIcons")]
        public async Task<IActionResult> GetGetAllCategories()
        {
            var result = await _mediator.Send(new GetAllIconsQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIcon([FromBody] Icon icon)
        {
            var command = new CreateIconCommand() { NewIcon = icon };

            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
