using Core.Entities.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MarketplaceDB;Trusted_Connection=true;TrustServerCertificate=True");
        }


        public DbSet<SupportUser> SupportUsers { get; set; }
        public DbSet<ShopOwner> ShopOwners { get; set; }
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ShopOwner to Shop (One-to-Many)
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.ShopOwner)
                .WithMany(so => so.Shops)
                .HasForeignKey(s => s.ShopOwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a ShopOwner if it has associated Shops

            // NormalUser to ShoppingCart (One-to-One)
            modelBuilder.Entity<NormalUser>()
                .HasOne(nu => nu.ShoppingCart)
                .WithOne(sc => sc.NormalUser)
                .HasForeignKey<ShoppingCart>(sc => sc.CustomerUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete the ShoppingCart if the associated NormalUser is deleted

            // ShoppingCart to CartItem (One-to-Many)
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.CartItems)
                .WithOne(ci => ci.ShoppingCart)
                .HasForeignKey(ci => ci.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade); // Delete CartItems if the associated ShoppingCart is deleted

            // Order to NormalUser (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.NormalUser)
                .WithMany(nu => nu.Orders)
                .HasForeignKey(o => o.CustomerUserId)
                .IsRequired(false) // Specify that NormalUserId is nullable
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete associated orders when the NormalUser is deleted

            // Order to Shop (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shops)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShopId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Shop if it has associated Orders

            // Order to OrderItem (One-to-Many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Delete OrderItems if the associated Order is deleted

            // OrderItem to Product (Many-to-One)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Products)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Product if it has associated OrderItems

            // Ticket to SupportUser (Many-to-One)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.SupportUser)
                .WithMany(su => su.Tickets)
                .HasForeignKey(t => t.SupportUserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a SupportUser if it has associated Tickets

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.CustomerUser)
                .WithMany() // Assuming a customer can have multiple tickets
                .HasForeignKey(t => t.CustomerUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany() // Assuming Category has a collection of products (one-to-many relationship)
                .HasForeignKey(p => p.CategoryId);

            // Product to CartItem (One-to-Many)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()  // Assuming Product does not need navigation back to CartItem
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Delete CartItems if the associated ShoppingCart is deleted


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
