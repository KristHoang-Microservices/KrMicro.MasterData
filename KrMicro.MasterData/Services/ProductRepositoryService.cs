using System.Linq.Expressions;
using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Services;

public interface IProductService : IBaseService<Product>
{
}

public class ProductRepositoryService : BaseRepositoryService<Product, MasterDataDbContext>, IProductService
{
    public ProductRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }

    public new async Task<IEnumerable<Product>> GetAllAsync()
    {
        try
        {
            return await DataContext.Set<Product>()
                .Include(product => product.Brand)
                .Include(product => product.Category)
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        }
    }

    public new async Task<Product> GetDetailAsync(Expression<Func<Product, bool>> predicate)
    {
        try
        {
            var result = await DataContext.Set<Product>()
                .Include(product => product.Brand)
                .Include(product => product.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);

            return result ?? new Product();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entities: {ex.Message}");
        }
    }
}