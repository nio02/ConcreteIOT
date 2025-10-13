using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Repository;

public class ProjectRepository : IProjectRepository
{
    private readonly Context _context;

    public ProjectRepository(Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Project project)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject is null)
            return false;

        existingProject.Name = project.Name;
        existingProject.Company = project.Company;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject is null)
            return false;

        _context.Projects.Remove(existingProject);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}