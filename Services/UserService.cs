using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Config;
using TechStore.Data;
using TechStore.DTOs.Auth;
using TechStore.DTOs.User;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class UserService : IUserRepository
    {
        protected readonly AppDbContext _context;
        protected readonly Utilities _utilities;

        public UserService(AppDbContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }
        public async Task Create(RegisterDTO user)
        {
            user.Password = _utilities.EncryptSHA256(user.Password);

            var newUser = new User
            {
                Name = user.Name.ToLower(),
                Address = user.Address.ToLower(),
                Telephone = user.Telephone,
                Email = user.Email.ToLower(),
                Password = user.Password,
                RolId = 3 // default value (client)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            var users = await _context.Users
            .Include(user => user.Rol)
            .Select(user => new UserDTO
            {
                Name = user.Name,
                Address = user.Address,
                Telephone = user.Telephone,
                Email = user.Email,
                Rol = user.Rol.Name
            }).ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var user = await _context.Users
            .Include(user => user.Rol)
            .FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDTO
            {
                Name = user.Name,
                Address = user.Address,
                Telephone = user.Telephone,
                Email = user.Email,
                Rol = user.Rol.Name
            };

            return userDto;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }


        public async Task Update(int id, User newInfo)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Id = id;
                user.Name = newInfo.Name.ToLower();
                user.Address = newInfo.Address.ToLower();
                user.Telephone = newInfo.Telephone;
                user.Email = newInfo.Email.ToLower();
                user.Password = _utilities.EncryptSHA256(newInfo.Password);
                user.RolId = newInfo.Id;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> Login(LoginDTO loginInfo)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginInfo.Email);

            if (user != null)
            {
                if (user.Password == _utilities.EncryptSHA256(loginInfo.Password))
                {
                    if (user.RolId == 1) // admin rol
                    {
                        var token = _utilities.GenerateJwtToken(user);
                        return token;
                    }

                    return "client";
                }

                return null;
            }

            return null;
        }
    }
}