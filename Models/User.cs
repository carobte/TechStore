using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required]
        public required string Name { get; set; }

        [Column("address")]
        [StringLength(255)]
        [Required]
        public required string Address { get; set; }

        [Column("telephone")]
        [StringLength(25)]
        [Required]
        [Phone]
        public required string Telephone { get; set; }

        [Column("email")]
        [StringLength(100)]
        [Required]
        [EmailAddress]
        public required string Email {get; set;}

        [Column("password")]
        [Required]
        [StringLength(100)]
        public required string Password {get; set;}

        [ForeignKey("rol_id")]
        [Column("rol_id")]
        public required int RolId { get; set; }
        public Rol Rol { get; set; }
        public required ICollection<Order> Orders { get; set; }

    }
}