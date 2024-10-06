using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTOs.Category;

namespace TechStore.Repositories
{
    public interface ICategoryRepository
    {    
        Task<IEnumerable<CategoryDTO>> Get();
        Task<CategoryDTO> GetById(int id);
        Task Create(CategoryDTO category);
        Task Delete(int id);
        Task Update(int id, CategoryDTO newInfo);
    }
}