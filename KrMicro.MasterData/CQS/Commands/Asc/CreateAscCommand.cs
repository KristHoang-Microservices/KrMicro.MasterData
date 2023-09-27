using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Asc;

public record CreateAscCommandRequest(string Name, string Address, string Hotline);

public class CreateAscCommandResult : CreateCommandResult<Models.Asc>
{
    public CreateAscCommandResult(Models.Asc? data, bool isSuccess = true, string? message = null) : base(data, message,
        isSuccess)
    {
    }
}