using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Brand;

public record GetBrandByIdQueryRequest;

public class GetBrandByIdQueryResult : GetByIdQueryResult<Models.Brand>
{
    public GetBrandByIdQueryResult(Models.Brand? data, bool isSuccess = true) : base(data, isSuccess)
    {
    }
}