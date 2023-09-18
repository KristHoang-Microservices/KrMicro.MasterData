﻿using KrMicro.Core.CQS.Query.Abstraction;

namespace KrMicro.MasterData.CQS.Query.Product;

public record GetAllProductQueryRequest;

public class GetAllProductQueryResult : GetAllQueryResult<Models.Product>
{
    public GetAllProductQueryResult(List<Models.Product> list) : base(list)
    {
    }
}