using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.User
{
    public class UserDTO
    {
         public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Telephone { get; set; }
        public required string Email { get; set; }
        public required string RolName { get; set; }
    }
}