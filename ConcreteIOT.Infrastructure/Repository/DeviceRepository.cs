using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Repository;

public class DeviceRepository : IDeviceRepository
{
    private readonly Context _context;

    public DeviceRepository(Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Device device)
    {
        await _context.Devices.AddAsync(device);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Device?> GetByIdAsync(Guid id)
    {
        return await _context.Devices.FindAsync(id);
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Devices.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Device device)
    {
        var existingDevice = await _context.Devices.FindAsync(id);
        if (existingDevice == null)
            return false;

        existingDevice.Serial = device.Serial;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingDevice = await _context.Devices.FindAsync(id);
        if (existingDevice == null)
            return false;
        
        _context.Devices.Remove(existingDevice);
        
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}