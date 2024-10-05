using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("createdAt")]
        [Required]
        public required DateTime CreatedAt { get; set; }  

        [Column("status")]
        [Required]
        public required  string Status {get;set;}    


        [ForeignKey("user_id")]
        [Column("user_id")]
        public required int UserId { get; set; }
        public User User { get; set; }

       // Many to Many relationship with Order with ProductOrder
       public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}