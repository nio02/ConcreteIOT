using ConcreteIOT.Application.Services;
using ConcreteIOT.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteIOT.Api.Controllers;

[ApiController]
public class UserProjectController : ControllerBase
{
    private readonly IUserProjectService _userProjectService;

    public UserProjectController(IUserProjectService userProjectService)
    {
        _userProjectService = userProjectService;
    }

    [HttpPost(ApiEndpoints.UserProject.AddVisitor)]
    public async Task<IActionResult> AddVisitor([FromRoute] Guid projectId, [FromBody] AddVisitorRequest request)
    {
        var result = await _userProjectService.AddVisitorToProject(projectId, request.email);
        if (!result)
            return NotFound();

        return Ok();
    }
}