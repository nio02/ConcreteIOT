using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.IRepository;

public interface IProjectRepository
{
    Task<bool> CreateAsync(Project project);
    Task<Project?> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, Project project);
    Task<bool> DeleteAsync(Guid id);
}