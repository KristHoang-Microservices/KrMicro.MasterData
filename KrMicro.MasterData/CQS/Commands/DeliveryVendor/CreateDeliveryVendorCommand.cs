using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.DeliveryVendor;

public record CreateDeliveryVendorCommandRequest(string Name, decimal Fee);

public class CreateDeliveryVendorCommandResult : CreateCommandResult<Models.DeliveryVendor>
{
    public CreateDeliveryVendorCommandResult(Models.DeliveryVendor? data, bool isSuccess = true, string? message = null) : base(data,
        message,
        isSuccess)
    {
    }
}