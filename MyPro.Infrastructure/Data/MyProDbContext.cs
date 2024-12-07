using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;

namespace MyPro.Infrastructure.Data;

public class MyProDbContext : DbContext
{
    public MyProDbContext(DbContextOptions<MyProDbContext> options) : base(options)
    {
    }

    public DbSet<TextEntry> TextEntries { get; set; }
}