using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Product;

public record GetProductsByIdsQueryRequest(List<short> ids);

public class GetProductsByIds : GetAllQueryResult<Models.Product>
{
    public GetProductsByIds(List<Models.Product> data) : base(data)
    {
    }
}