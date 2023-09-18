using KrMicro.Core.Models.Abstraction;
using KrMicro.MasterData.Constants;
using KrMicro.MasterData.CQS.Command.Brand;
using KrMicro.MasterData.CQS.Query.Brand;
using KrMicro.MasterData.Models;
using KrMicro.MasterData.Services;
using Microsoft.AspNetCore.Mvc;

namespace KrMicro.MasterData.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService categoryService)
    {
        _brandService = categoryService;
    }

    // GET: api/Brand
    [HttpGet]
    public async Task<ActionResult<GetAllBrandQueryResult>> GetBrand()
    {
        return new GetAllBrandQueryResult(new List<Brand>(await _brandService.GetAllAsync()));
    }

    // GET: api/Brand/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetBrandByIdQueryResult>> GetBrand(short id)
    {
        var item = await _brandService.GetDetailAsync(item => item.Id == id);

        if (item.Id == null) return BadRequest();

        return new GetBrandByIdQueryResult(item);
    }

    // PATCH: api/Brand/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateBrandCommandResult>> PatchBrand(short id, UpdateBrandCommandRequest request)
    {
        var item = await _brandService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();
        item.Name = request.Name ?? item.Name;
        item.Description = request.Description ?? item.Description;
        item.ImageUrl = request.ImageUrl ?? item.ImageUrl;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _brandService.UpdateAsync(item);
        return new UpdateBrandCommandResult(result);
    }


    // POST: api/Brand
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CreateBrandCommandResult>> CreateBrand(CreateBrandCommandRequest request)
    {
        var newItem = new Brand
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            ImageUrl = request.ImageUrl,
            Status = Status.Disable
        };
        var result = await _brandService.InsertAsync(newItem);
        return new CreateBrandCommandResult(result);
    }

    // POST: api/Brand/id
    [HttpPost("{id}/UpdateStatus")]
    public async Task<ActionResult<UpdateBrandStatusCommandResult>> UpdateStatus(short id,
        UpdateBrandStatusRequest request)
    {
        var item = await _brandService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();
        item.Status = request.Status;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        await _brandService.UpdateAsync(item);

        return new UpdateBrandStatusCommandResult(NetworkSuccessResponse.UpdateStatusSuccess);
    }

    private async Task<bool> BrandExists(short id)
    {
        return await _brandService.CheckExistsAsync(e => e.Id == id);
    }
}