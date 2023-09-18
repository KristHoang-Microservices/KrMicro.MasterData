using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Category;

public record UpdateCategoryCommandRequest(string? Name);

public class UpdateCategoryCommandResult : UpdateCommandResult<Models.Category>
{
    public UpdateCategoryCommandResult(Models.Category? data, string? message = null, bool isSuccess = true) : base(
        data, message, isSuccess)
    {
    }
}