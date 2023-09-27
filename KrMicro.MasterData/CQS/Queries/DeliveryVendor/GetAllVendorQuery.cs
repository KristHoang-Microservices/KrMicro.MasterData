using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.DeliveryVendor;

public record GetAllDeliveryVendorQueryRequest;

public class GetAllDeliveryVendorQueryResult : GetAllQueryResult<Models.DeliveryVendor>
{
    public GetAllDeliveryVendorQueryResult(List<Models.DeliveryVendor> list) : base(list)
    {
    }
}