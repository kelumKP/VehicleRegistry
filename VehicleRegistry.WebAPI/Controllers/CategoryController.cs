using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.Core.Models;

namespace VehicleRegistry.WebAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetGetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDetailsDto category) 
        {
            var command = new CreateCategoryCommand() { NewCategory = category };
            
            var result = await _mediator.Send(command);
            
            return Ok(result);

        }
    }
}
