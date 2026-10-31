using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Data;

public class AppDbContext : DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Writer> Writers { get; set; }
     public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
