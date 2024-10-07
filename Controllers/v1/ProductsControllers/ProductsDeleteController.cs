using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductsControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    [Authorize]
    public class ProductsDeleteController : ProductsControllers
    {
        public ProductsDeleteController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Delete product",
        Description = "Delete product, using its Id")]
        [SwaggerResponse(204, "product deleted successfully")]

        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.Delete(id);
            return NoContent();
        }
    }
}