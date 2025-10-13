using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Repository;

public class UserProjectRepository : IUserProjectRepository
{
    private readonly Context _context;

    public UserProjectRepository(Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(UserProject userProject)
    {
        await _context.UserProject.AddAsync(userProject);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteByProjectAsync(Guid projectId)
    {
        var userProjects = await _context.UserProject
            .Where(p => p.ProjectId == projectId)
            .ToListAsync();

        if (userProjects.Count == 0)
            return false;

        _context.UserProject.RemoveRange(userProjects);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}