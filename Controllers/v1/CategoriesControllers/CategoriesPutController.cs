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
    public class CategoriesPutController : CategoriesController
    {
        public CategoriesPutController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
        
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update category",
            Description = "Update category, finding it by Id and putting the newInfo"
        )]
        [SwaggerResponse(200, "Category updated")]
        [SwaggerResponse(400, "Bad request, please try again")]

        public async Task<IActionResult> Update(int id, CategoryDTO newInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryRepository.Update(id, newInfo);
            return Ok("Category updated");
        }
    }
}