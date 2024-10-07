using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.CategoriesControllers
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("categories")]
    [Authorize]
    public class CategoriesDeleteController : CategoriesController
    {
        public CategoriesDeleteController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Delete category",
        Description = "Delete category, using its Id")]
        [SwaggerResponse(204, "Category deleted successfully")]

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.Delete(id);
            return NoContent();
        }
    }
}