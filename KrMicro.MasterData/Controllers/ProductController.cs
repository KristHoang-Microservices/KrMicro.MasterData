using KrMicro.Core.Models.Abstraction;
using KrMicro.MasterData.Constants;
using KrMicro.MasterData.CQS.Commands.Product;
using KrMicro.MasterData.CQS.Queries.Product;
using KrMicro.MasterData.Models;
using KrMicro.MasterData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrMicro.MasterData.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class ProductController : ControllerBase
{
    private readonly IBrandService _brandService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IProductSizeService _productSizeService;
    private readonly ISizeService _sizeService;

    public ProductController(IBrandService brandService, ICategoryService categoryService,
        IProductService productService, ISizeService sizeService, IProductSizeService productSizeService)
    {
        _brandService = brandService;
        _categoryService = categoryService;
        _productService = productService;
        _sizeService = sizeService;
        _productSizeService = productSizeService;
    }

    // GET: api/Product
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllProductQueryResult>> GetProducts(
        [FromQuery] GetAllProductQueryRequest queryRequest)
    {
        var filter = new ProductQueryFilter(queryRequest);

        var list =
            new List<Product>(await _productService.GetAllAsync());

        list = list.FindAll(p => filter.Validate(p));
        return Ok(new GetAllProductQueryResult(list));
    }

    // GET: api/Product
    [HttpGet("Ids")]
    [AllowAnonymous]
    public async Task<ActionResult<GetProductsByIds>> GetProductsByIds([FromQuery] GetProductsByIdsQueryRequest request)
    {
        return Ok(new GetProductsByIds(
            new List<Product>(
                await _productService.GetAllWithFilterAsync(x => request.ids.ToList().Contains(x.Id ?? -1)))));
    }

    // GET: api/Product/Web
    [HttpGet("Web")]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllProductQueryResult>> GetProductsWeb()
    {
        return Ok(new GetAllProductQueryResult(
            new List<Product>(await _productService.GetAllAsync()).FindAll(p => p.Status == Status.Available)));
    }

    // GET: api/Product/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetProductByIdQueryResult>> GetProduct(short id)
    {
        var item = await _productService.GetDetailAsync(item => item.Id == id);

        if (item == null) return new BadRequestResult();

        return Ok(new GetProductByIdQueryResult(item));
    }

    // GET: api/Product/Category/{categoryId}
    [HttpGet("/Category/{categoryId}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetProductByIdQueryResult>> GetProductCategoryById(short categoryId)
    {
        var category = await _categoryService.GetDetailAsync(c => c.Id == categoryId);
        if (category == null) return BadRequest("Không tìm thấy Danh mục");
        var item = await _productService.GetDetailAsync(item =>
            item.CategoryId == categoryId || item.OtherCategories.Contains(category));

        if (item == null) return new BadRequestResult();

        return Ok(new GetProductByIdQueryResult(item));
    }

    // GET: api/Product/5?sizeCode=100ml
    [HttpGet("{id}/{sizeCode}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetProductSizeQuery>> GetProductSize(short id, string sizeCode)
    {
        var item = await _productSizeService.GetDetailAsync(item =>
            item.ProductId == id && item.Size.SizeCode == sizeCode);

        if (item == null) return new BadRequestResult();

        return Ok(new GetProductSizeQuery(new ProductSizeResult
        {
            SizeId = item.SizeId,
            ProductId = item.ProductId,
            Stock = item.Stock,
            Price = item.Price
        }, true));
    }

    // PATCH: api/Product/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateProductCommandResult>> PatchProduct(short id,
        UpdateProductCommandRequest request)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item == null) return NotFound();

        item.Name = request.Name ?? item.Name.Trim();
        item.Description = request.Description ?? item.Description?.Trim();
        item.ImportFrom = request.ImportFrom ?? item.ImportFrom?.Trim();
        item.ReleaseYear = request.ReleaseYear ?? item.ReleaseYear;
        item.FragranceDescription = request.FragranceDescription ?? item.FragranceDescription?.Trim();
        item.Style = request.Style ?? item.Style?.Trim();
        item.ImageUrls = request.ImageUrls ?? item.ImageUrls?.Trim();

        item = await _productService.UpdateAsync(item);

        if (request.BrandName != null)
        {
            var brand = await _brandService.GetDetailAsync(x => x.Name == request.BrandName) ??
                        await _brandService.InsertAsync(new Brand
                        {
                            Name = request.BrandName.Trim(),
                            CreatedAt = DateTimeOffset.UtcNow,
                            Status = Status.Available
                        });

            item.Brand = null;
            item.BrandId = null;
            await _productService.UpdateAsync(item);
            item.BrandId = brand.Id;
        }

        if (request.CategoryName != null)
        {
            var category = await _categoryService.GetDetailAsync(x => x.Name == request.CategoryName) ??
                           await _categoryService.InsertAsync(new Category
                           {
                               Name = request.CategoryName.Trim(),
                               CreatedAt = DateTimeOffset.UtcNow,
                               Status = Status.Available
                           });

            item.Category = null;
            item.CategoryId = null;
            await _productService.UpdateAsync(item);
            item.CategoryId = category.Id;
        }

        var result = item;
        if (request.BrandName != null || request.CategoryName != null) result = await _productService.AttachAsync(item);
        return Ok(new UpdateProductCommandResult(result));
    }

    // POST: api/Product
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CreateProductCommandResult>> CreateProduct(CreateProductCommandRequest request)
    {
        var newItem = new Product
        {
            Name = request.Name,
            CreatedAt = DateTimeOffset.UtcNow,
            Description = request.Description?.Trim(),
            ImportFrom = request.ImportFrom?.Trim(),
            ReleaseYear = request.ReleaseYear,
            FragranceDescription = request.FragranceDescription?.Trim(),
            Style = request.Style?.Trim(),
            Status = Status.Available,
            ImageUrls = request.ImageUrls?.Trim()
        };

        newItem = await _productService.InsertAsync(newItem);

        if (request.BrandName != null)
        {
            var brand = await _brandService.GetDetailAsync(x => x.Name == request.BrandName) ??
                        await _brandService.InsertAsync(new Brand
                        {
                            Name = request.BrandName.Trim(),
                            CreatedAt = DateTimeOffset.UtcNow,
                            Status = Status.Available
                        });

            newItem.Brand = brand;
        }

        if (request.CategoryName != null)
        {
            var category = await _categoryService.GetDetailAsync(x => x.Name == request.CategoryName) ??
                           await _categoryService.InsertAsync(new Category
                           {
                               Name = request.CategoryName.Trim(),
                               CreatedAt = DateTimeOffset.UtcNow,
                               Status = Status.Available
                           });

            newItem.Category = category;
        }

        var result = newItem;
        if (request.BrandName != null || request.CategoryName != null)
            result = await _productService.AttachAsync(newItem);
        return Ok(new CreateProductCommandResult(result));
    }

    // POST: api/Product/id
    [HttpPost("{id}/UpdateStatus")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateProductStatusCommandResult>> UpdateStatus(short id,
        UpdateProductStatusRequest request)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item == null) return BadRequest();

        item.Status = request.Status;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        await _productService.UpdateAsync(item);

        return Ok(new UpdateProductStatusCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    }

    [HttpPost("{id}/UpdateStock")]
    public async Task<ActionResult<UpdateProductStockCommandResult>> UpdateStock(short id,
        UpdateProductStockRequest request)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item == null) return BadRequest();
        // await _productService.AttachAsync(item);

        var delTasks = new List<Task>();
        foreach (var ps in item.ProductSizes) delTasks.Add(Task.Run(() => _productSizeService.DeleteAsync(ps)));

        foreach (var t in delTasks)
            await t;

        foreach (var record in request.productSizes)
        {
            var size = await _sizeService.GetDetailAsync(x => x.SizeCode == record.SizeCode);
            if (size == null)
                size = await _sizeService.InsertAsync(new Size
                {
                    SizeCode = record.SizeCode.Trim(), CreatedAt = DateTimeOffset.UtcNow, Status = Status.Available
                });
            else
                size.UpdatedAt = DateTimeOffset.UtcNow;

            var productSize = await _productSizeService.GetDetailAsync(x => x.SizeId == size.Id && x.ProductId == id);

            if (productSize == null)
            {
                productSize = await _productSizeService.InsertAsync(new ProductSize
                {
                    Stock = record.Stock ?? 0,
                    Price = record.Price ?? 0,
                    ProductId = item.Id ?? -1,
                    SizeId = size.Id ?? -1
                });
            }
            else
            {
                productSize.Stock = record.Stock ?? productSize.Stock;
                productSize.Price = record.Price ?? productSize.Price;
            }

            await _productSizeService.UpdateAsync(productSize);
            await _sizeService.UpdateAsync(size);
        }

        item.ProductSizes = new List<ProductSize>();

        await _productService.UpdateAsync(item);

        return Ok(new UpdateProductStockCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    }

    [HttpPost("{id}/{sizeCode}/UpdateStockSingle")]
    public async Task<ActionResult> UpdateStockWithCode(short id, string sizeCode,
        UpdateProductStockSingleRequest request)
    {
        try
        {
            var item = await _productService.GetDetailAsync(x => x.Id == id);
            if (item == null) return BadRequest();

            var size = await _sizeService.GetDetailAsync(x => x.SizeCode == sizeCode);
            var productSize =
                await _productSizeService.GetDetailAsync(x => x.ProductId == id && x.SizeId == (size!.Id ?? -1));

            if (productSize != null)
            {
                productSize.Stock = request.Stock;
                await _productSizeService.UpdateAsync(productSize);
            }
        }
        catch (Exception e)
        {
            return BadRequest(new UpdateProductStockCommandResult(e.Message, false));
        }

        return Ok(new UpdateProductStockCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UpdateProductCommandResult>> DeleteProduct(short id)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item == null) return BadRequest();
        item.Status = Status.Deleted;

        await _productService.UpdateAsync(item);
        return Ok(new UpdateProductStockCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    }

    private async Task<bool> ProductExists(short id)
    {
        return await _productService.CheckExistsAsync(e => e.Id == id);
    }
}