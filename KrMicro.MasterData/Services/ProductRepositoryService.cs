using KrMicro.Core.Services;
using KrMicro.MasterData.CQS.Queries.Product;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;

namespace KrMicro.MasterData.Services;

public interface IProductService : IBaseService<Product>
{
    Task<IEnumerable<Product>> GetAllWithQuery(GetAllProductQueryRequest request);
}

public class ProductRepositoryService : BaseRepositoryService<Product, MasterDataDbContext>, IProductService
{
    public ProductRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAllWithQuery(GetAllProductQueryRequest request)
    {
        var result = DataContext.Products
            .Where(p => !request.CategoryId.HasValue || p.CategoryId == request.CategoryId) // Filter by categoryId
            .Where(p => !request.CategoryId.HasValue ||
                        p.OtherCategories.Any(oc => oc.Id == request.CategoryId)) // Filter by otherCategoryId
            .Where(p => !request.BrandId.HasValue || p.BrandId == request.BrandId);


        return await Task.FromResult(result.AsEnumerable());
    }
}