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


    public DbSet<Product> Product { get; set; }

    public DbSet<Asc> Asc { get; set; }

    public DbSet<Category> Category { get; set; }

    public DbSet<Brand> Brand { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        options.UseSqlServer(configuration.GetConnectionString("DbSQL"));
    }
}