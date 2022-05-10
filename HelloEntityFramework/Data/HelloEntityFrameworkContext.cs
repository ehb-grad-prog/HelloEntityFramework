using HelloEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloEntityFramework.Data;

public class HelloEntityFrameworkContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;

    public HelloEntityFrameworkContext(DbContextOptions<HelloEntityFrameworkContext> options) : base(options)
    {
        //
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
