using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public interface IProjectService
{
    Task<bool> CreateAsync(Project project, Guid userId);
    Task<Project?> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, Project project);
    Task<bool> DeleteAsync(Guid id);
}