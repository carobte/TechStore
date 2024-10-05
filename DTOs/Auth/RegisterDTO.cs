using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.Auth
{
    public class RegisterDTO
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Telephone { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int RolId { get; set; }

    }
}