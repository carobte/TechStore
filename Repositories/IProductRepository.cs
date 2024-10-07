using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTOs.Product;

namespace TechStore.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task Create(ProductDTO product);
        Task Delete(int id);
        Task Update(int id, ProductDTO newInfo);
    }
}