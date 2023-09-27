using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.DeliveryVendor;

public record UpdateDeliveryVendorCommandRequest(string? Name, decimal? Fee);

public class UpdateDeliveryVendorCommandResult : UpdateCommandResult<Models.DeliveryVendor>
{
    public UpdateDeliveryVendorCommandResult(Models.DeliveryVendor? data, bool isSuccess = true, string? message = null) : base(data,
        message, isSuccess)
    {
    }
}