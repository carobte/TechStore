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
        public async Task Create(User user)
        {
            user.Password = _utilities.EncryptSHA256(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(int id, User newInfo)
        {
            var user = await GetById(id);
            if (user != null)
            {             
                user.Id = id;
                user.Name = newInfo.Name;
                user.Address = newInfo.Address;
                user.Telephone = newInfo.Telephone;
                user.Email = newInfo.Email;
                user.Password = _utilities.EncryptSHA256( newInfo.Password);
                user.RolId = newInfo.Id;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}