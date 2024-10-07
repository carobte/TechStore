using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductsControllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsControllers : ControllerBase
    {
        protected readonly IProductRepository _productRepository;

        public ProductsControllers(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}