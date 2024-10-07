using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.Product
{
    public class ProductDTO
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required int Stock { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required int CategoryId { get; set; }
        public string Category { get; set; }
    }
}