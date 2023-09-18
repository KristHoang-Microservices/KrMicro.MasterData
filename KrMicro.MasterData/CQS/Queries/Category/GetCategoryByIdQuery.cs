using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Category;

public record GetCategoryByIdQueryRequest;

public class GetCategoryByIdQueryResult : GetByIdQueryResult<Models.Category>
{
    public GetCategoryByIdQueryResult(Models.Category? data, bool isSuccess = true) : base(data, isSuccess)
    {
    }
}