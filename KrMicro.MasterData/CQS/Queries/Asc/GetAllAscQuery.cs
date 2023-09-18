using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Asc;

public record GetAllAscQueryRequest;

public class GetAllAscQueryResult : GetAllQueryResult<Models.Asc>
{
    public GetAllAscQueryResult(List<Models.Asc> list) : base(list)
    {
    }
}