using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using R.I.S.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Repositories
{
    public class RISContext : DbContext
    {
        public RISContext() { }
        public RISContext(DbContextOptions<RISContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProductList)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.ProductList)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ReviewList)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReviewList)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RIS;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
