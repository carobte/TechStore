using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductsControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    public class ProductsGetController : ProductsControllers
    {
        public ProductsGetController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Get products",
          Description = "Returns all the products in database")]
        [SwaggerResponse(200, "Ok: Returns all the products in database")]
        [SwaggerResponse(204, "No Content: There are not products in the database")]

        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.Get();

            if (products == null || !products.Any())
            {
                return NoContent();
            }

            return Ok(products);
        }
    }
}