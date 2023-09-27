using KrMicro.Core.Services;
using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Models;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Services;

public interface IDeliveryVendorService : IBaseService<DeliveryVendor>
{
}

public class DeliveryVendorRepositoryService : BaseRepositoryService<DeliveryVendor, MasterDataDbContext>, IDeliveryVendorService
{
    public DeliveryVendorRepositoryService(MasterDataDbContext dataContext) : base(dataContext)
    {
    }
}