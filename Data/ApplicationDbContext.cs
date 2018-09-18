using Microsoft.EntityFrameworkCore;
using MyfirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyfirstApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7BGFQJH;Database=ApiProductMVC;Trusted_connection=True");
        }

        //Bd set perfom Crud Operation
        public DbSet<Product> Products { get; set; }
    }
}
