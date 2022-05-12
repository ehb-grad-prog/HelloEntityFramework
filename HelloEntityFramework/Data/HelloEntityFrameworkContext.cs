using HelloEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloEntityFramework.Data;

public class HelloEntityFrameworkContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Translation> Translations { get; set; } = null!;

    public HelloEntityFrameworkContext(DbContextOptions<HelloEntityFrameworkContext> options) : base(options)
    {
        //
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>().HasData(
            new Translation
            {
                Id = 1,
                Key = "Welcome",
                Value = "Welkom",
                Language = "nl"
            },
            new Translation
            {
                Id = 2,
                Key = "Welcome",
                Value = "Bienvenue",
                Language = "fr"
            }
        );
    }
}
