using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("products")]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required]
        public required string Name { get; set; }

        [Column("description")]
        [StringLength(255)]
        [Required]

        public required string Description { get; set; }

        [Column("price")]
        [Required]
        public required decimal Price { get; set; }

        [Column("stock")]
        [Required]
        public required int Stock { get; set; }   
        
        [ForeignKey("category_id")]
        [Column("category_id")]
        public required int CategoryId { get; set; }
        public Category Category { get; set; }

        // Many to Many relationship with Order with ProductOrder
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }

}