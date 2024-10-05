using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductOrder> ProductOrders {get;set;}
        public DbSet<Rol> Roles {get;set;}
        public DbSet<User> Users {get;set;}
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}