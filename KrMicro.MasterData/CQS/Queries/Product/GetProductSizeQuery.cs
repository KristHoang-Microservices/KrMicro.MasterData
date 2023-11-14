using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Queries.Product;

public class ProductSizeResult
{
    public short ProductId { get; set; }
    public short SizeId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class GetProductSizeQuery : GetByIdQueryResult<ProductSizeResult>
{
    public GetProductSizeQuery(ProductSizeResult? data, bool isSuccess) : base(data, isSuccess)
    {
    }
}