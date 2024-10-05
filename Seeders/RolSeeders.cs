using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Seeders
{
    public class RolSeeders
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Name = "admin" },
                new Rol { Id = 2, Name = "employee" },
                new Rol { Id = 3, Name = "client" }
            );
        }
    }
}

