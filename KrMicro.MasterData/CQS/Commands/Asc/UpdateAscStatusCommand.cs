using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Asc;

public record UpdateAscStatusRequest(Status Status);

public class UpdateAscStatusCommandResult : UpdateStatusCommandResult
{
    public UpdateAscStatusCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}