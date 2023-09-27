using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Brand;

public record UpdateBrandStatusRequest(Status Status);

public class UpdateBrandStatusCommandResult : UpdateStatusCommandResult
{
    public UpdateBrandStatusCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}