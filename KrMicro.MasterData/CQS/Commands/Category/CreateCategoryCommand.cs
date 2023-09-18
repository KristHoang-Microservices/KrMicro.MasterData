using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Category;

public record CreateCategoryCommandRequest(string Name);

public class CreateCategoryCommandResult : CreateCommandResult<Models.Category>
{
    public CreateCategoryCommandResult(Models.Category? data, bool isSuccess = true, string? message = null) : base(
        data, message, isSuccess)
    {
    }
}