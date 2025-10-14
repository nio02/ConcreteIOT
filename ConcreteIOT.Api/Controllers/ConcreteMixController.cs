using ConcreteIOT.Api.Mapping;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Application.Services;
using ConcreteIOT.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteIOT.Api.Controllers;

[ApiController]
public class ConcreteMixController : ControllerBase
{
    private readonly IConcreteMixService _concreteMixService;

    public ConcreteMixController(IConcreteMixService concreteMixService)
    {
        _concreteMixService = concreteMixService;
    }

    [HttpPost(ApiEndpoints.ConcreteMix.Create)]
    public async Task<IActionResult> Create([FromRoute] Guid projectId, [FromBody] CreateConcreteMixRequest request)
    {
        var mix = request.MapToConcreteMix();
        
        var created = await _concreteMixService.CreateAsync(projectId, mix);
        if (!created)
            return BadRequest("Concrete mix could not be created");

        var response = mix.MapToResponse();
        
        return CreatedAtAction(nameof(Get), 
            new { projectId, id = mix.Id }, 
            response);
    }

    [HttpGet(ApiEndpoints.ConcreteMix.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid projectId, [FromRoute] Guid id)
    {
        var mix = await _concreteMixService.GetByIdAsync(projectId, id);
        if (mix is null)
            return NotFound();

        return Ok(mix);
    }

    [HttpGet(ApiEndpoints.ConcreteMix.GetAll)]
    public async Task<IActionResult> GetAll([FromRoute] Guid projectId)
    {
        var mixes = await _concreteMixService.GetAllByProjectAsync(projectId);
        return Ok(mixes);
    }

    [HttpPut(ApiEndpoints.ConcreteMix.Update)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid projectId, [FromRoute] Guid id, [FromBody] ConcreteMix mix)
    {
        var updated = await _concreteMixService.UpdateAsync(projectId, id, mix);
        if (!updated)
            return NotFound("Project or Mix not found");
        return Ok();
    }

    [HttpDelete(ApiEndpoints.ConcreteMix.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid projectId, [FromRoute] Guid id)
    {
        var deleted = await _concreteMixService.DeleteAsync(projectId, id);
        if (!deleted)
            return NotFound("Project or Mix not found");
        return Ok();
    }
}