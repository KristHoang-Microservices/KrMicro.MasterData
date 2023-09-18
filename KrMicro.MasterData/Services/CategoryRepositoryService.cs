using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;

namespace KrMicro.MasterData.Services;

public interface ICategoryService : IBaseService<Category>
{
}

public class CategoryRepositoryService : BaseRepositoryService<Category, MasterDataDbContext>, ICategoryService
{
    public CategoryRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}