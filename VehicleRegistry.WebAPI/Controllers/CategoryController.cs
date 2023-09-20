#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.Application.Category.Commands.DeleteCategory;
using VehicleRegistry.Application.Category.Commands.UpdateCategory;
using VehicleRegistry.Application.Category.Queries.GetAllCategories;
using VehicleRegistry.Application.Category.Queries.GetCategoryById;

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

        /// <summary>
        /// Get a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The category details if found, or NotFound if not.</returns>
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

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>A list of all categories.</returns>
        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name="category">The category details to create.</param>
        /// <returns>The created category details.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDetailsDto category)
        {
            var command = new CreateCategoryCommand() { NewCategory = category };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="updatedCategory">The updated category details.</param>
        /// <returns>The updated category details if found, or NotFound if not.</returns>
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

        /// <summary>
        /// Delete a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>NoContent if successful, or NotFound if the category was not found.</returns>
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
