using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTOs.Auth;
using TechStore.DTOs.User;
using TechStore.Models;

namespace TechStore.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> Get();
        Task<UserDTO> GetById(int id);
        Task Create(RegisterDTO user);
        Task Delete(int id);
        Task Update(int id, User newInfo);
        Task<string> Login(LoginDTO loginInfo);
    }
}