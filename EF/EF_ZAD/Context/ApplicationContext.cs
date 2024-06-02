using EF_ZAD.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_ZAD.Context;

public class ApplicationContext : DbContext
{
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public ApplicationContext()
    {
    }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Accounts)
            .UsingEntity<ShoppingCart>();

    }
}