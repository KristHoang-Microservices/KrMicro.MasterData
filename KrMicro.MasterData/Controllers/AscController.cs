using KrMicro.Core.Models.Abstraction;
using KrMicro.MasterData.Constants;
using KrMicro.MasterData.CQS.Commands.Asc;
using KrMicro.MasterData.CQS.Queries.Asc;
using KrMicro.MasterData.Models;
using KrMicro.MasterData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrMicro.MasterData.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AscController : ControllerBase
{
    private readonly IAscService _ascService;

    public AscController(IAscService categoryService)
    {
        _ascService = categoryService;
    }

    // GET: api/Asc
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllAscQueryResult>> GetAsc()
    {
        return new GetAllAscQueryResult(new List<Asc>(await _ascService.GetAllAsync()));
    }

    // GET: api/Asc/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetAscByIdQueryResult>> GetAsc(short id)
    {
        var item = await _ascService.GetDetailAsync(item => item.Id == id);

        if (item.Id == null) return BadRequest();

        return new GetAscByIdQueryResult(item);
    }

    // PATCH: api/Asc/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateAscCommandResult>> PatchAsc(short id, UpdateAscCommandRequest request)
    {
        var item = await _ascService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();
        item.Name = request.Name ?? item.Name;
        item.Hotline = request.Hotline ?? item.Hotline;
        item.Address = request.Address ?? item.Address;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _ascService.UpdateAsync(item);
        return new UpdateAscCommandResult(result);
    }


    // POST: api/Asc
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<CreateAscCommandResult> CreateAsc(CreateAscCommandRequest request)
    {
        var newItem = new Asc
        {
            Name = request.Name,
            Address = request.Address,
            Hotline = request.Hotline,
            CreatedAt = DateTimeOffset.UtcNow,
            Status = Status.Disable
        };
        var result = await _ascService.InsertAsync(newItem);
        return new CreateAscCommandResult(result);
    }

    // POST: api/Asc/id
    [HttpPost("{id}/UpdateStatus")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateAscStatusCommandResult>> UpdateStatus(short id, UpdateAscStatusRequest request)
    {
        var item = await _ascService.GetDetailAsync(x => x.Id == id);
        if (item.Id == null) return BadRequest();

        item.Status = request.Status;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        await _ascService.UpdateAsync(item);

        return new UpdateAscStatusCommandResult(NetworkSuccessResponse.UpdateStatusSuccess);
    }

    private async Task<bool> AscExists(short id)
    {
        return await _ascService.CheckExistsAsync(e => e.Id == id);
    }
}