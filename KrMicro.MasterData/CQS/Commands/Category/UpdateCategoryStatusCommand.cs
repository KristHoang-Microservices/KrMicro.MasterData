using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Category;

public record UpdateCategoryStatusRequest(Status Status);

public class UpdateCategoryStatusCommandResult : UpdateStatusCommandResult
{
    public UpdateCategoryStatusCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}