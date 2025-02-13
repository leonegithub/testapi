using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "cd6a7ac2-0bab-4c0a-9619-6efe2408d97e", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "SuperUser", NormalizedName = "SUPERUSER" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Clothing" },
            new Category { CategoryId = 3, CategoryName = "Home & Kitchen" },
            new Category { CategoryId = 4, CategoryName = "Books" },
            new Category { CategoryId = 5, CategoryName = "Beauty & Personal Care" },
            new Category { CategoryId = 6, CategoryName = "Sports & Outdoors" },
            new Category { CategoryId = 7, CategoryName = "Toys & Games" },
            new Category { CategoryId = 8, CategoryName = "Automotive" },
            new Category { CategoryId = 9, CategoryName = "Health & Household" },
            new Category { CategoryId = 10, CategoryName = "Pet Supplies" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Smartphone", CategoryId = 1, Price = 699.99M, isAvailable = true },
            new Product { ProductId = 2, Name = "Laptop", CategoryId = 1, Price = 999.99M, isAvailable = true },
            new Product { ProductId = 3, Name = "T-Shirt", CategoryId = 2, Price = 19.99M, isAvailable = false },
            new Product { ProductId = 4, Name = "Blender", CategoryId = 3, Price = 49.99M, isAvailable = true },
            new Product { ProductId = 5, Name = "Novel", CategoryId = 4, Price = 14.99M, isAvailable = false },
            new Product { ProductId = 6, Name = "Shampoo", CategoryId = 5, Price = 5.99M, isAvailable = true },
            new Product { ProductId = 7, Name = "Basketball", CategoryId = 6, Price = 29.99M, isAvailable = true },
            new Product { ProductId = 8, Name = "Board Game", CategoryId = 7, Price = 39.99M, isAvailable = false },
            new Product { ProductId = 9, Name = "Car Tire", CategoryId = 8, Price = 79.99M, isAvailable = true },
            new Product { ProductId = 10, Name = "Vitamins", CategoryId = 9, Price = 12.99M, isAvailable = true },
            new Product { ProductId = 11, Name = "Dog Food", CategoryId = 10, Price = 24.99M, isAvailable = true }
        );


        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "ccbee901-52ce-465c-a34e-5474a89b0fb9",
                FirstName = "Admin Supreme",
                PasswordHash = "AQAAAAIAAYagAAAAEA67pJDvnTW5K0Wj0vuteAADa4fL8xqSJ8KAzBAwi+2jeI0asAhcB+GIy2lCcZYDiw==",
                Role = "Admin",
                UserName = "admin@domain.com",
                NormalizedUserName = "ADMIN@DOMAIN.COM",
                Email = "admin@domain.com",
                NormalizedEmail = "ADMIN@DOMAIN.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "1"
            }
        );

        /* modelBuilder.Entity<IdentityUserRole<string>>().HasData(
           new IdentityUserRole<string>
           {
               UserId = "ccbee901-52ce-465c-a34e-5474a89b0fb9",
               RoleId = "cd6a7ac2-0bab-4c0a-9619-6efe2408d97e"
           }
       ); */

        modelBuilder.Entity<ApplicationUser>()
            .Property(u => u.Role)
            .HasColumnName("Role");

        modelBuilder.Entity<Order>()
         .HasMany(o => o.OrderItems)
         .WithOne(e => e.Order)
         .HasForeignKey(e => e.OrderId)
         .IsRequired();



    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}