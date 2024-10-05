using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("product_orders")]
    public class ProductOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("quantity")]
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("product_id")]
        [Column("product_id")]
        public required int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("order_id")]
        [Column("order_id")]
        public required int OrderId { get; set; }
        public Order Order { get; set; }
    }
}