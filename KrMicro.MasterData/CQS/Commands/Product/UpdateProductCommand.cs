using KrMicro.Core.CQS.Command.Abstraction;

namespace KrMicro.MasterData.CQS.Command.Product;

public record UpdateProductCommandRequest(string? Name, decimal? Price, string? Description, string? BrandName,
    string? CategoryName,
    string? ImportFrom, short? ReleaseYear, string? FragranceDescription, string? Style, string? ImageUrls);

public class UpdateProductCommandResult : UpdateCommandResult<Models.Product>
{
    public UpdateProductCommandResult(Models.Product? data, bool isSuccess = true, string? message = null) : base(data,
        message, isSuccess)
    {
    }
}