using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Services;

public interface IAscService : IBaseService<Asc>
{
}

public class AscRepositoryService : BaseRepositoryService<Asc, MasterDataDbContext>, IAscService
{
    public AscRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}