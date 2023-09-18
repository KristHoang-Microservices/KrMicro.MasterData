using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Brand;

public record UpdateBrandCommandRequest(string? Name, string? Description, string? ImageUrl);

public class UpdateBrandCommandResult : UpdateCommandResult<Models.Brand>
{
    public UpdateBrandCommandResult(Models.Brand? data, bool isSuccess = true, string? message = null) : base(data,
        message, isSuccess)
    {
    }
}