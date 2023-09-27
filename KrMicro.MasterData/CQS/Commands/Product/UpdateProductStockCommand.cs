using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Product;

public record UpdateProductStockRequest(int Stock);

public class UpdateProductStockCommandResult : UpdateStatusCommandResult
{
    public UpdateProductStockCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}