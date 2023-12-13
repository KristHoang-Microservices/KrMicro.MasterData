using System.Linq.Expressions;
using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Product;

public class ProductQueryFilter : AbstractFilter<Models.Product>
{
    private readonly GetAllProductQueryRequest _request;

    public ProductQueryFilter(GetAllProductQueryRequest request)
    {
        _request = request;
    }

    protected override List<Expression<Func<Models.Product, bool>>> AddRequestToExpression(Models.Product data)
    {
        var exp = new List<Expression<Func<Models.Product, bool>>>
        {
            x => !_request.CategoryId.HasValue || _request.CategoryId == data.CategoryId ||
                 data.OtherCategories.Any(c => c.Id == _request.CategoryId),
            x => !_request.BrandId.HasValue || _request.BrandId == data.BrandId
        };
        return exp;
    }
}