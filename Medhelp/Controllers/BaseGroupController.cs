using Medhelp.Contracts.Groups;
using Medhelp.Services.Abstractions.Groups;
using Microsoft.AspNetCore.Mvc;

namespace Medhelp.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseGroupController<TModel>(IBaseGroupService<TModel> service) : ControllerBase
    where TModel : GroupModel
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TModel>> GetById(Guid id)
    {
        var result = await service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TModel>>> GetList()
    {
        var result = await service.GetListAsync();
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TModel>> Update(Guid id, [FromBody] GroupDto item)
    {
        try
        {
            var result = await service.UpdateAsync(id, item);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<TModel>> Add([FromBody] GroupDto item)
    {
        try
        {
            var result = await service.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<TModel>> Delete(Guid id)
    {
        var result = await service.DeleteAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id:guid}/medicines")]
    public async Task<ActionResult<IEnumerable<MedicineShortInfo>>> GetMedicines(Guid id)
    {
        var result = await service.GetMedicinesAsync(id);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<TModel>>> Find([FromQuery] string searchTerm)
    {
        var result = await service.FindAsync(searchTerm);
        return Ok(result);
    }
}