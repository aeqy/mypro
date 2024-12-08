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
    
    public DbSet<BOM> BOMs { get; set; }
    
    public DbSet<BomMaterial> BomMaterials { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        // 配置实体映射
        
        model.Entity<MaterialType>().ToTable("MaterialTypes");

        // Bom 关联 物料信息
        model.Entity<BomMaterial>()
            .HasKey(bm => new { bm.BOMId, bm.MaterialTypeId });
        
        model.Entity<BomMaterial>()
            .HasOne( bm => bm.BOM)
            .WithMany( b => b.BomMaterials)
            .HasForeignKey( bm => bm.BOMId );

        model.Entity<BomMaterial>()
            .HasOne( bm => bm.MaterialType)
            .WithMany()
            .HasForeignKey( bm => bm.MaterialTypeId );
    }
}