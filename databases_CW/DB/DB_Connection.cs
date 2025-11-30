using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace databases_CW.DB
{
    public class AppDbContext : DbContext
    {
        // Таблицы в БД
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        // Настройка подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Для SQL Server
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=ShopDb;User Id=sa;Password=your_password;");

            // Для PostgreSQL
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=bookshop;Username=postgres;Password=password");
        }

        // Настройка моделей (опционально)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Установка ограничения на длину имени
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.Name)
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    // Установка точности для цены
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.Price)
        //        .HasColumnType("decimal(10, 2)");
        //}
    }
}
