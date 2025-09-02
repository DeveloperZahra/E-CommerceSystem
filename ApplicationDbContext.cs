using E_CommerceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Category> Categories { get; set; } // DbSet for Categories → creates a table "Categories" in the database

        public DbSet<Supplier> Suppliers {  get; set; } // DbSet for Suppliers → creates a table "Suppliers" in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Email)
                        .IsUnique();

            // Configure relationship: Product ↔ Category (many-to-one)
            modelBuilder.Entity<Product>()                         // Configure Product entity
                       .HasOne(p => p.Category)                   // Each Product has one Category
                       .WithMany(c => c.Products)                 // Each Category has many Products
                      .HasForeignKey(p => p.CategoryId)          // Foreign key in Product is CategoryId
                       .OnDelete(DeleteBehavior.Restrict);        // Restrict delete (cannot delete Category if Products exist)

            // Configure relationship: Product ↔ Supplier (many-to-one)
            modelBuilder.Entity<Product>()                         // Configure Product entity
                        .HasOne(p => p.Supplier)                   // Each Product has one Supplier
                          .WithMany(s => s.Products)                 // Each Supplier has many Products
                          .HasForeignKey(p => p.SupplierId)          // Foreign key in Product is SupplierId

        }
    }
}
