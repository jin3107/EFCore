using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private const string connectionString = @"Server=localhost;Database=ShopData;User=root;Password=Chuong@030905;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information);
            // Using the `LogTo()` method of the `DbContextOptionBuilder`
            // The `LogTo()` method takes an `Action` as a parameter
        }
    }
}
