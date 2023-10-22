using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;

namespace KrMicro.MasterData.Services;

public interface IProductSizeService : IBaseService<ProductSize>
{
}

public class ProductSizeRepositoryService : BaseRepositoryService<ProductSize, MasterDataDbContext>, IProductSizeService
{
    public ProductSizeRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}