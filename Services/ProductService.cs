using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.DTOs.Product;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class ProductService : IProductRepository
    {
        protected readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductDTO product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _context.Products
            .Include(product => product.Category)
            .Select(product => new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.Category.Id,
                Category = product.Category.Name

            }).ToListAsync();

            return products;
        }

        public async Task Update(int id, ProductDTO newInfo)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Name = newInfo.Name;
                product.Description = newInfo.Description;
                product.Price = newInfo.Price;
                product.Stock = newInfo.Stock;
                product.CategoryId = newInfo.CategoryId;

                _context .Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}