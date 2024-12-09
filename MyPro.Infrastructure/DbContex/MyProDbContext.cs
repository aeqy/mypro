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
        model.Entity<MaterialType>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.OwnsOne(m => m.Price, price =>
            {
                price.Property(p => p.Amount).HasColumnName("PriceAmount");
                price.Property(p => p.Currency).HasColumnName("PriceCurrency");
            });

            entity.OwnsOne(m => m.Stock, stock =>
            {
                stock.Property(s => s.Quantity).HasColumnName("StockQuantity");
            });
        });
        
        base.OnModelCreating(model);
    }
}