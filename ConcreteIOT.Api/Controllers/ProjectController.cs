using ConcreteIOT.Api.Mapping;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Application.Services;
using ConcreteIOT.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteIOT.Api.Controllers;

[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost(ApiEndpoints.Projects.Create)]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
    {
        var userId = request.userId;
        var project = request.MapToProject();
        
        var created = await _projectService.CreateAsync(project, userId);
        if (!created)
            return BadRequest("Project could not be created");

        var response = project.MapToResponse();
        
        return CreatedAtAction(nameof(Get), new { id = project.Id }, response);
    }

    [HttpGet(ApiEndpoints.Projects.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpGet(ApiEndpoints.Projects.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllAsync();

        return Ok(projects);
    }

    [HttpPut(ApiEndpoints.Projects.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Project project)
    {
        var result = await _projectService.UpdateAsync(id, project);
        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete(ApiEndpoints.Projects.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _projectService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}