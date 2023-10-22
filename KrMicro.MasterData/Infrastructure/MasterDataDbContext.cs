using KrMicro.MasterData.Models;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Infrastructure;

public class MasterDataDbContext : DbContext
{
    public MasterDataDbContext()
    {
    }

    public MasterDataDbContext(DbContextOptions<MasterDataDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Asc> Ascs { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<DeliveryVendor> DeliveryVendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DeliveryVendor>().Property(c => c.Fee).HasPrecision(18, 2);

        modelBuilder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany().HasForeignKey(c => c.CategoryId)
            .IsRequired(false);
        modelBuilder.Entity<Product>().HasOne<Brand>(p => p.Brand).WithMany().HasForeignKey(c => c.BrandId)
            .IsRequired(false);
        modelBuilder.Entity<Product>().HasMany<ProductSize>(p => p.ProductSizes).WithOne(s => s.Product)
            .HasForeignKey("ProductSizes");

        modelBuilder.Entity<ProductSize>().HasOne<Size>(p => p.Size).WithMany(s => s.ProductSizes)
            .HasForeignKey("SizeId").IsRequired();

        modelBuilder.Entity<ProductSize>().HasKey(p => new { p.SizeId, p.ProductId });

        modelBuilder.Entity<ProductSize>().Navigation(c => c.Size).AutoInclude();


        modelBuilder.Entity<Product>().Navigation(c => c.Brand).AutoInclude();
        modelBuilder.Entity<Product>().Navigation(c => c.Category).AutoInclude();
        modelBuilder.Entity<Product>().Navigation(c => c.ProductSizes).AutoInclude();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        options.UseNpgsql(configuration.GetConnectionString("DbNeon"));
    }
}