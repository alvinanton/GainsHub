using GainsHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GainsHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wellcore - Pure Micronised Creatine Monohydrate",
                    Description = "Unflavoured (100g, 33 Servings) | Rapid Absorption | Enhanced Muscle Strength and Power | Fast Recovery | Increased Muscle Mass",
                    Price = 539.99m,
                    StockQuantity = 5,
                    ImageUrl = "https://m.media-amazon.com/images/I/51B9614MvZL._AC_UF1000,1000_QL80_.jpg",
                    IsVisible = true

                },
                new Product
                {
                    Id = 2,
                    Name = "Nutrabay Gold Micronised Creatine Monohydrate Powder",
                    Description = "120g, Orange | NABL Lab Tested | 3g Creatine/Serving | Increases Muscle Mass, Strength & Power | Pre & Post Workout Supplement | For Men & Women",
                    Price = 379.99m,
                    StockQuantity = 9,
                    ImageUrl = "https://m.media-amazon.com/images/I/712pPYduEPL._SL1500_.jpg",
                    IsVisible = true

                });

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Health & Personal Care", },
                new Category { Id = 2, Name = "Diet & Nutrition", },
                new Category { Id = 3, Name = "Minerals & Supplements" },
                new Category { Id = 4, Name = "Vitamins" });

            builder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 3 },
                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 2 },
                new ProductCategory { ProductId = 2, CategoryId = 3 },
                new ProductCategory { ProductId = 2, CategoryId = 4 });
        }
    }
}
