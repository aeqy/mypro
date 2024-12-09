using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;

namespace MyPro.Infrastructure.DbContex;

public class MyProDbContext: DbContext
{
    public MyProDbContext(DbContextOptions<MyProDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<TextEntry> TextEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}