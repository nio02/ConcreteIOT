using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.IRepository;

public interface IUserProjectRepository
{
    Task<bool> CreateAsync(UserProject userProject);
    Task<bool> DeleteByProjectAsync(Guid projectId);
}