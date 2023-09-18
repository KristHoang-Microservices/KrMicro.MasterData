using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Product;

public record UpdateProductStatusRequest(Status Status);

public class UpdateProductStatusCommandResult : UpdateStatusCommandResult
{
    public UpdateProductStatusCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}