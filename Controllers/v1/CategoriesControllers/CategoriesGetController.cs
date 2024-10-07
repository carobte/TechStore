using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.CategoriesControllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("categories")]
    public class CategoriesGetController : CategoriesController
    {
        public CategoriesGetController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Get categories",
          Description = "Returns all the categories in database")]
        [SwaggerResponse(200, "Ok: Returns all the categories in database")]
        [SwaggerResponse(204, "No Content: There are not categories in the database")]

        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.Get();

            if (categories == null || !categories.Any())
            {
                return NoContent();
            }

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Get category by id",
           Description = "Returns the specific category information"
       )]
        [SwaggerResponse(200, "Ok: Returns the category information")]
        [SwaggerResponse(404, "Not found: There is not category with that id")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}