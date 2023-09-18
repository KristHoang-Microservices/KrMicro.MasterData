using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Brand;

public record GetAllBrandQueryRequest;

public class GetAllBrandQueryResult : GetAllQueryResult<Models.Brand>
{
    public GetAllBrandQueryResult(List<Models.Brand> list) : base(list)
    {
    }
}