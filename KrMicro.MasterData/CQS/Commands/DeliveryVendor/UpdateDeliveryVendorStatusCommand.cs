using KrMicro.Core.CQS.Command.Abstraction;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.CQS.Commands.DeliveryVendor;

public record UpdateDeliveryVendorStatusRequest(Status Status);

public class UpdateDeliveryVendorStatusCommandResult : UpdateStatusCommandResult
{
    public UpdateDeliveryVendorStatusCommandResult(string message, bool isSuccess = true) : base(message, isSuccess)
    {
    }
}