using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Product;

public record GetAllProductQueryRequest(short? CategoryId, short? BrandId);

public class GetAllProductQueryResult : GetAllQueryResult<Models.Product>
{
    public GetAllProductQueryResult(List<Models.Product> list) : base(list)
    {
    }
}