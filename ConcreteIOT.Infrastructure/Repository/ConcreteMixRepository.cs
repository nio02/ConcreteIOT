using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Repository;

public class ConcreteMixRepository : IConcreteMixRepository
{
    private readonly Context _context;

    public ConcreteMixRepository(Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(ConcreteMix mix)
    {
        await _context.ConcreteMixes.AddAsync(mix);

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<ConcreteMix?> GetByIdAsync(Guid id)
    {
        return await _context.ConcreteMixes.FindAsync(id);
    }

    public async Task<IEnumerable<ConcreteMix>> GetAllByProjectAsync(Guid projectId)
    {
        var projects = await _context.ConcreteMixes
            .Where(m => m.ProjectId == projectId)
            .ToListAsync();

        return projects;
    }

    public async Task<bool> UpdateAsync(Guid id, ConcreteMix mix)
    {
        var existingMix = await _context.ConcreteMixes.FindAsync(id);
        if (existingMix is null)
            return false;

        existingMix.Name = mix.Name;
        existingMix.MixA = mix.MixA;
        existingMix.MixB = mix.MixB;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingMix = await _context.ConcreteMixes.FindAsync(id);
        if (existingMix is null)
            return false;

        _context.ConcreteMixes.Remove(existingMix);
        
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}