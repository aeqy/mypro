using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;

namespace MyPro.Infrastructure.DbContex;

public class MyProDbContext: DbContext
{
    public MyProDbContext(DbContextOptions<MyProDbContext> options) : base(options)
    {
    }
    
    public DbSet<TextEntry> TextEntries { get; init; }
    
    public DbSet<BomComponent?> BomComponents { get; init; }
    public DbSet<MaterialType> MaterialTypes { get; init; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        // 配置实体映射
        
        model.Entity<MaterialType>().ToTable("MaterialTypes");

        // Bom 关联 物料信息
        // 配置 BOMComponent 实体的复合主键，由 ParentMaterialId 和 ChildMaterialId 组成
        model.Entity<BomComponent>()
            .HasKey(bc => new { bc.ParentMaterialId, bc.ChildMaterialId });

        // 配置 BOMComponent 与 ParentMaterial 的一对多关系
        // 一个 ParentMaterial 可以有多个 BOMComponent
        model.Entity<BomComponent>()
            .HasOne(bc => bc.ParentMaterial)
            .WithMany(m => m.BomComponents)
            .HasForeignKey(bc => bc.ParentMaterialId);

        // 配置 BOMComponent 与 ChildMaterial 的一对多关系
        // 一个 ChildMaterial 可以出现在多个 BOMComponent 中
        model.Entity<BomComponent>()
            .HasOne(bc => bc.ChildMaterial)
            .WithMany() // 这里不需要导航属性，因为我们不需要从 ChildMaterial 导航到 BOMComponent
            .HasForeignKey(bc => bc.ChildMaterialId);
    }
}