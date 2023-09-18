﻿using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Product;

public record CreateProductCommandRequest(string Name, decimal Price, string? Description, string? BrandName,
    string? CategoryName,
    string? ImportFrom, short? ReleaseYear, string? FragranceDescription, string? Style, string? ImageUrls);

public class CreateProductCommandResult : CreateCommandResult<Models.Product>
{
    public CreateProductCommandResult(Models.Product? data, bool isSuccess = true, string? message = null) : base(data,
        message,
        isSuccess)
    {
    }
}