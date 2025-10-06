using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public interface IDeviceService
{
    Task<bool> CreateAsync(Device device);
    Task<Device?> GetByIdAsync(Guid id);
    Task<IEnumerable<Device>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, Device device);
    Task<bool> DeleteAsync(Guid id);
}