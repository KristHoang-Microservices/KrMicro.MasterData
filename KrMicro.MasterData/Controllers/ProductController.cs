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
    public async Task<ActionResult<GetAllProductQueryResult>> GetProducts()
    {
        return Ok(new GetAllProductQueryResult(new List<Product>(await _productService.GetAllAsync())));
    }

    // GET: api/Product/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetProductByIdQueryResult>> GetProduct(short id)
    {
        var item = await _productService.GetDetailAsync(item => item.Id == id);

        if (item.Id == null) return new BadRequestResult();

        return Ok(new GetProductByIdQueryResult(item));
    }

    // PATCH: api/Product/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateProductCommandResult>> PutProduct(short id,
        UpdateProductCommandRequest request)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return NotFound();

        item.Name = request.Name ?? item.Name;
        item.Description = request.Description ?? item.Description;
        item.ImportFrom = request.ImportFrom ?? item.ImportFrom;
        item.ReleaseYear = request.ReleaseYear ?? item.ReleaseYear;
        item.FragranceDescription = request.FragranceDescription ?? item.FragranceDescription;
        item.Style = request.Style ?? item.Style;
        item.ImageUrls = request.ImageUrls ?? item.ImageUrls;

        item = await _productService.UpdateAsync(item);

        if (request.BrandName != null)
        {
            var brand = await _brandService.GetDetailAsync(x => x.Name == request.BrandName);
            if (brand.Id == null)
                brand = await _brandService.InsertAsync(new Brand
                {
                    Name = request.BrandName,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = Status.Available
                });

            item.Brand = brand;
        }

        if (request.CategoryName != null)
        {
            var category = await _categoryService.GetDetailAsync(x => x.Name == request.CategoryName);
            if (category.Id == null)
                category = await _categoryService.InsertAsync(new Category
                {
                    Name = request.CategoryName,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = Status.Available
                });

            item.Category = category;
        }

        var result = item;
        if (request.BrandName != null || request.CategoryName != null) result = await _productService.AttackAsync(item);
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
            Description = request.Description,
            ImportFrom = request.ImportFrom,
            ReleaseYear = request.ReleaseYear,
            FragranceDescription = request.FragranceDescription,
            Style = request.Style,
            Status = Status.Available,
            ImageUrls = request.ImageUrls
        };

        newItem = await _productService.InsertAsync(newItem);

        if (request.BrandName != null)
        {
            var brand = await _brandService.GetDetailAsync(x => x.Name == request.BrandName);
            if (brand.Id == null)
                brand = await _brandService.InsertAsync(new Brand
                {
                    Name = request.BrandName,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = Status.Available
                });

            newItem.Brand = brand;
        }

        if (request.CategoryName != null)
        {
            var category = await _categoryService.GetDetailAsync(x => x.Name == request.CategoryName);
            if (category.Id == null)
                category = await _categoryService.InsertAsync(new Category
                {
                    Name = request.CategoryName,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = Status.Available
                });

            newItem.Category = category;
        }

        var result = newItem;
        if (request.BrandName != null || request.CategoryName != null)
            result = await _productService.AttackAsync(newItem);
        return Ok(new CreateProductCommandResult(result));
    }

    // POST: api/Product/id
    [HttpPost("{id}/UpdateStatus")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateProductStatusCommandResult>> UpdateStatus(short id,
        UpdateProductStatusRequest request)
    {
        var item = await _productService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();

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
        if (item.Id == null) return BadRequest();

        var size = await _sizeService.GetDetailAsync(x => x.SizeCode == request.SizeCode);

        if (size.Id == null) size = await _sizeService.InsertAsync(new Size { SizeCode = request.SizeCode });

        var productSize = await _productSizeService.GetDetailAsync(x => x.SizeId == size.Id && x.ProductId == id);

        if (productSize.Id == null)
            productSize = await _productSizeService.InsertAsync(new ProductSize { Product = item, Size = size });

        item.UpdatedAt = DateTimeOffset.UtcNow;
        size.UpdatedAt = DateTimeOffset.UtcNow;
        productSize.UpdatedAt = DateTimeOffset.UtcNow;
        await _productService.UpdateAsync(item);
        await _sizeService.UpdateAsync(size);
        await _productSizeService.UpdateAsync(productSize);

        return Ok(new UpdateProductStockCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    }

    private async Task<bool> ProductExists(short id)
    {
        return await _productService.CheckExistsAsync(e => e.Id == id);
    }
}