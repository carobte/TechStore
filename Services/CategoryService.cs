using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Config;
using TechStore.Data;
using TechStore.DTOs.Category;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class CategoryService : ICategoryRepository
    {
        protected readonly AppDbContext _context;
       
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(CategoryDTO category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var categories = await _context.Categories
            .Select(category => new CategoryDTO
            {
                Name = category.Name,
                Description = category.Description
            }).ToListAsync();

            return categories;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _context.Categories
            .FindAsync(id);
            
            var categoryDto = new CategoryDTO
            {
                Name = category.Name,
                Description = category.Description
            };

            return categoryDto;
        }

        public async Task Update(int id, CategoryDTO newInfo)
        {
             var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.Name = newInfo.Name.ToLower();
                category.Description = newInfo.Description.ToLower();

                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}