using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Asc;

public record UpdateAscCommandRequest(string? Name, string? Address, string? Hotline);

public class UpdateAscCommandResult : UpdateCommandResult<Models.Asc>
{
    public UpdateAscCommandResult(Models.Asc? data, string? message = null, bool isSuccess = true) : base(data,
        message, isSuccess)
    {
    }
}