using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("categories")]
    public class Category
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Product name is required.")]      
        public required string Name { get; set; }
        
        [Column("description")]
        [StringLength(255)]    
        [Required(ErrorMessage = "Product description is required.")]      
        public required string Description { get; set; }
        
        public required ICollection<Product> Products { get; set; }
    }
}