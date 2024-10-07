using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.Category;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.CategoriesControllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("categories")]
    public class CategoriesPostController : CategoriesController
    {
        public CategoriesPostController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create category",
            Description = "Register category in database"
        )]
        [SwaggerResponse(204, "Created: category registered successfully")]
        [SwaggerResponse(400, "Bad request")]

        public async Task<IActionResult> Post(CategoryDTO newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryRepository.Create(newCategory);
            return NoContent();
        }
        
    }
}