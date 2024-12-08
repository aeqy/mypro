using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;

namespace MyPro.Infrastructure.DbContex;

public class MyProDbContext: DbContext
{
    public MyProDbContext(DbContextOptions<MyProDbContext> options) : base(options)
    {
    }
    
    public DbSet<TextEntry> TextEntries { get; set; }
    
    public DbSet<MaterialType> MaterialTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        // 配置实体映射
        
        model.Entity<MaterialType>().ToTable("MaterialTypes");

    }
}