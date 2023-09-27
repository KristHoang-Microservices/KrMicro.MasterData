using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Product;

public record GetProductByIdQueryRequest;

public class GetProductByIdQueryResult : GetByIdQueryResult<Models.Product>
{
    public GetProductByIdQueryResult(Models.Product? data, bool isSuccess = true) : base(data, isSuccess)
    {
    }
}