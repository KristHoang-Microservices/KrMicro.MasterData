using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Category;

public record GetAllCategoryQueryRequest;

public class GetAllCategoryQueryResult : GetAllQueryResult<Models.Category>
{
    public GetAllCategoryQueryResult(List<Models.Category> list) : base(list)
    {
    }
}