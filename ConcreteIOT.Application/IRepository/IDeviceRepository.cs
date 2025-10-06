using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.IRepository;

public interface IDeviceRepository
{
    Task<bool> CreateAsync(Device device);
    Task<Device?> GetByIdAsync(Guid id);
    Task<IEnumerable<Device>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, Device device);
    Task<bool> DeleteAsync(Guid id);
}