using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.Category
{
    public class CategoryDTO
    {
        [Required]
        public required string Name {get;set;}

        [Required]
        public required string Description {get;set;}
    }
}