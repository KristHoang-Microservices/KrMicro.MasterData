using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;

namespace KrMicro.MasterData.Services;

public interface IBrandService : IBaseService<Brand>
{
}

public class BrandRepositoryService : BaseRepositoryService<Brand, MasterDataDbContext>, IBrandService
{
    public BrandRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}