using KrMicro.Core.Models.Abstraction;
using KrMicro.MasterData.Constants;
using KrMicro.MasterData.CQS.Commands.Category;
using KrMicro.MasterData.CQS.Queries.Category;
using KrMicro.MasterData.Models;
using KrMicro.MasterData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrMicro.MasterData.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/Category
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllCategoryQueryResult>> GetCategories()
    {
        return new GetAllCategoryQueryResult(new List<Category>(await _categoryService.GetAllAsync()));
    }

    // GET: api/Category/Web
    [HttpGet("Web")]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllCategoryQueryResult>> GetCategoriesWeb()
    {
        return new GetAllCategoryQueryResult(
            new List<Category>(await _categoryService.GetAllAsync()).FindAll(c => c.Status == Status.Available));
    }

    // GET: api/Category/Menu
    [HttpGet("Menu")]
    [AllowAnonymous]
    public async Task<ActionResult<GetAllCategoryQueryResult>> GetCategoriesMenu()
    {
        return new GetAllCategoryQueryResult(
            new List<Category>(await _categoryService.GetAllAsync()).FindAll(c => c.IsMenu));
    }

    // GET: api/Category/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GetCategoryByIdQueryResult>> GetCategory(short id)
    {
        var item = await _categoryService.GetDetailAsync(item => item.Id == id);
        if (item == null) return BadRequest();
        return new GetCategoryByIdQueryResult(item);
    }

    // PATCH: api/Category/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateCategoryCommandResult>> PutCategory(short id,
        UpdateCategoryCommandRequest request)
    {
        var item = await _categoryService.GetDetailAsync(x => x.Id == id);
        if (item == null) return BadRequest();
        item.Name = request.Name ?? item.Name;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _categoryService.UpdateAsync(item);
        return new UpdateCategoryCommandResult(result);
    }


    // POST: api/Category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CreateCategoryCommandResult>> CreateCategory(CreateCategoryCommandRequest request)
    {
        var newItem = new Category
        {
            Name = request.Name,
            CreatedAt = DateTimeOffset.UtcNow,
            Status = Status.Disable
        };
        var result = await _categoryService.InsertAsync(newItem);
        return new CreateCategoryCommandResult(result);
    }

    // POST: api/Category/id
    [HttpPost("{id}/UpdateStatus")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdateCategoryStatusCommandResult>> UpdateStatus(short id,
        UpdateCategoryStatusRequest request)
    {
        var item = await _categoryService.GetDetailAsync(x => x.Id == id);
        if (item == null) return BadRequest();

        item.Status = request.Status;
        item.UpdatedAt = DateTimeOffset.UtcNow;
        await _categoryService.UpdateAsync(item);

        return new UpdateCategoryStatusCommandResult(NetworkSuccessResponse.UpdateStatusSuccess);
    }

    private async Task<bool> CategoryExists(short id)
    {
        return await _categoryService.CheckExistsAsync(e => e.Id == id);
    }
}