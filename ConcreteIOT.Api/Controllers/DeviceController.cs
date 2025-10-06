using ConcreteIOT.Application.Models;
using ConcreteIOT.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteIOT.Api.Controllers;

[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpPost(ApiEndpoints.Devices.Create)]
    public async Task<IActionResult> Create([FromBody] Device device)
    {
        var created = await _deviceService.CreateAsync(device);

        if (!created)
            return BadRequest("Device could not be created");

        return CreatedAtAction(nameof(Get), new { id = device.Id }, device);
    }

    [HttpGet(ApiEndpoints.Devices.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var device = await _deviceService.GetByIdAsync(id);
        if (device is null)
            return NotFound();

        return Ok(device);
    }

    [HttpGet(ApiEndpoints.Devices.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var devices = await _deviceService.GetAllAsync();

        return Ok(devices);
    }

    [HttpPut(ApiEndpoints.Devices.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Device device)
    {
        var result = await _deviceService.UpdateAsync(id, device);
        if (!result)
            return NotFound();

        return Ok($"Device {id} has been updated successfully");
    }

    [HttpDelete(ApiEndpoints.Devices.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _deviceService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return Ok(result);
    }
}