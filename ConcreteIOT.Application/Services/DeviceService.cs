using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;

    public DeviceService(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }


    public async Task<bool> CreateAsync(Device device)
    {
        return await _deviceRepository.CreateAsync(device);
    }

    public async Task<Device?> GetByIdAsync(Guid id)
    {
        return await _deviceRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _deviceRepository.GetAllAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Device device)
    {
        return await _deviceRepository.UpdateAsync(id, device);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _deviceRepository.DeleteAsync(id);
    }
}