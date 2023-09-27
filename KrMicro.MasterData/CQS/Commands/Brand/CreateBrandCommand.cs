using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Brand;

public record CreateBrandCommandRequest(string Name, string? Description, string? ImageUrl);

public class CreateBrandCommandResult : CreateCommandResult<Models.Brand>
{
    public CreateBrandCommandResult(Models.Brand? data, bool isSuccess = true, string? message = null) : base(data,
        message, isSuccess)
    {
    }
}