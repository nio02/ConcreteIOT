using ConcreteIOT.Application.Models;
using ConcreteIOT.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteIOT.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost(ApiEndpoints.Users.Create)]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var created = await _userService.CreateAsync(user);
        if (!created)
            return BadRequest("User could not be created");

        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    
    [HttpGet(ApiEndpoints.Users.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }
    
    [HttpGet(ApiEndpoints.Users.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }

    [HttpPut(ApiEndpoints.Users.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] User user)
    {
        var result = await _userService.UpdateAsync(id, user);
        if (!result)
            return NotFound();
        
        return Ok(result);
    }

    [HttpDelete(ApiEndpoints.Users.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _userService.DeleteAsync(id);
        if (!result)
            return NotFound();
        
        return Ok();
    }
}