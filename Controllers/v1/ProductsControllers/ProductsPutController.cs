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
    public class ProductsPutController : ProductsControllers
    {
        public ProductsPutController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
    Summary = "Update product",
    Description = "Update product, finding it by Id and putting the newInfo")]
        [SwaggerResponse(200, "product updated")]
        [SwaggerResponse(400, "Bad request, please try again")]

        public async Task<IActionResult> Update(int id, ProductDTO newInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productRepository.Update(id, newInfo);
            return Ok("product updated");
        }
    }
}