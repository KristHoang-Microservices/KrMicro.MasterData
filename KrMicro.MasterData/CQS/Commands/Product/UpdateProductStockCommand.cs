using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Product;

public record UpdateProductStockRequest(int Stock, string SizeCode);

public class UpdateProductStockCommandResult : UpdateStatusCommandResult
{
    public UpdateProductStockCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}