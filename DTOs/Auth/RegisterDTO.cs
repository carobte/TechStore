using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Address { get; set; }
        [Phone]
        [Required]
        public required string Telephone { get; set; }
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }

    }
}