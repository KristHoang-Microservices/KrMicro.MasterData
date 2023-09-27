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
}