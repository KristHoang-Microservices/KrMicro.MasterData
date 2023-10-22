using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;

namespace KrMicro.MasterData.Services;

public interface ISizeService : IBaseService<Size>
{
}

public class SizeRepositoryService : BaseRepositoryService<Size, MasterDataDbContext>, ISizeService
{
    public SizeRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}