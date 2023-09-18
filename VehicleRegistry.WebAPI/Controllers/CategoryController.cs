using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Commands.DeleteCategory;
using VehicleRegistry.Application.Category.Commands.UpdateCategory;
using VehicleRegistry.Application.Category.Commands.UpdateCategory.VehicleRegistry.Application.Category.Commands.UpdateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.Application.Category.Queries.GetCategoryById;
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

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery { CategoryId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(result);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDetailsDto updatedCategory)
        {
            var command = new UpdateCategoryCommand
            {
                CategoryId = id, // Make sure UpdateCategoryCommand has a CategoryId property
                UpdatingCategory = updatedCategory
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { CategoryId = id };

            var result = await _mediator.Send(command);

            if (result) // Check if result is not null or empty (assuming it's a collection)
            {
                return NoContent(); // HTTP 204 No Content
            }
            else
            {
                return NotFound("Category not found.");
            }
        }
    }
}
