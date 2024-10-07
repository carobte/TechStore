using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.Product;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductsControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    [Authorize]
    public class ProductsPostController : ProductsControllers
    {
        public ProductsPostController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create product",
            Description = "Register product in database"
        )]
        [SwaggerResponse(204, "Created: product registered successfully")]
        [SwaggerResponse(400, "Bad request")]

        public async Task<IActionResult> Post(ProductDTO newproduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productRepository.Create(newproduct);
            return NoContent();
        }
    }
}