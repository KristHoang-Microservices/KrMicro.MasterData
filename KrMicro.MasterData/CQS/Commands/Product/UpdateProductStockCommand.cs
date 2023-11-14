using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.Product;

public record StockRecord(int? Stock, string SizeCode, decimal? Price);

public record UpdateProductStockSingleRequest(int Stock);

public record UpdateProductStockRequest(List<StockRecord> productSizes);

public class UpdateProductStockCommandResult : UpdateStatusCommandResult
{
    public UpdateProductStockCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}