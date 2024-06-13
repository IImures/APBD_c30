using JWT.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public ApplicationContext()
    {
    }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
}