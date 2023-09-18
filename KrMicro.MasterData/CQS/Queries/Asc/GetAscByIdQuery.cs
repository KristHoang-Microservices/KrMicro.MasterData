using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Asc;

public record GetAscByIdQueryRequest;

public class GetAscByIdQueryResult : GetByIdQueryResult<Models.Asc>
{
    public GetAscByIdQueryResult(Models.Asc? data, bool isSuccess = true) : base(data, isSuccess)
    {
    }
}