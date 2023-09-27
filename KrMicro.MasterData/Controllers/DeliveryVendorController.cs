using KrMicro.Core.Models.Abstraction;
using KrMicro.MasterData.Constants;
using KrMicro.MasterData.CQS.Commands.DeliveryVendor;
using KrMicro.MasterData.CQS.Queries.DeliveryVendor;
using KrMicro.MasterData.Models;
using KrMicro.MasterData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrMicro.MasterData.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class DeliveryVendorController : ControllerBase
{
    private readonly IBrandService _brandService;
    private readonly ICategoryService _categoryService;
    private readonly IDeliveryVendorService _deliveryVendorService;

    public DeliveryVendorController(IDeliveryVendorService productService, IBrandService brandService,
        ICategoryService categoryService)
    {
        _deliveryVendorService = productService;
        _brandService = brandService;
        _categoryService = categoryService;
    }

    // GET: api/DeliveryVendor
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllDeliveryVendorQueryResult>> GetDeliveryVendor()
    {
        return new GetAllDeliveryVendorQueryResult(new List<DeliveryVendor>(await _deliveryVendorService.GetAllAsync()));
    }

    // GET: api/DeliveryVendor/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetDeliveryVendorByIdQueryResult>> GetDeliveryVendorById(short id)
    {
        var item = await _deliveryVendorService.GetDetailAsync(item => item.Id == id);

        if (item.Id == null) return new BadRequestResult();

        return new GetDeliveryVendorByIdQueryResult(item);
    }

    // PATCH: api/DeliveryVendor/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateDeliveryVendorCommandResult>> PutDeliveryVendor(short id,
        UpdateDeliveryVendorCommandRequest request)
    {
        var item = await _deliveryVendorService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();

        item.Name = request.Name ?? item.Name;
        item.Fee = request.Fee ?? item.Fee;

        item = await _deliveryVendorService.UpdateAsync(item);
        
        var result = item;
        
        return Ok(new UpdateDeliveryVendorCommandResult(result));
    }


    // POST: api/DeliveryVendor
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CreateDeliveryVendorCommandResult>> CreateDeliveryVendor(CreateDeliveryVendorCommandRequest request)
    {
        var newItem = new DeliveryVendor
        {
            Name = request.Name,
            Fee = request.Fee,
            CreatedAt = DateTimeOffset.UtcNow,
            Status = Status.Disable,
        };

        newItem = await _deliveryVendorService.InsertAsync(newItem);

        return Ok(new CreateDeliveryVendorCommandResult(newItem));
    }

    // POST: api/DeliveryVendor/id
    [HttpPost("{id}/UpdateStatus")]
    public async Task<ActionResult<UpdateDeliveryVendorStatusCommandResult>> UpdateStatus(short id,
        UpdateDeliveryVendorStatusRequest request)
    {
        var item = await _deliveryVendorService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();

        item.Status = request.Status;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        await _deliveryVendorService.UpdateAsync(item);

        return Ok(new UpdateDeliveryVendorStatusCommandResult(NetworkSuccessResponse.UpdateStatusSuccess));
    } 

    private async Task<bool> DeliveryVendorExists(short id)
    {
        return await _deliveryVendorService.CheckExistsAsync(e => e.Id == id);
    }
}