using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.Auth
{
    public class RegisterDTO
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        [Phone]
        public required string Telephone { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}