using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.DeliveryVendor;

public record GetDeliveryVendorByIdQueryRequest;

public class GetDeliveryVendorByIdQueryResult : GetByIdQueryResult<Models.DeliveryVendor>
{
    public GetDeliveryVendorByIdQueryResult(Models.DeliveryVendor? data, bool isSuccess = true) : base(data, isSuccess)
    {
    }
}