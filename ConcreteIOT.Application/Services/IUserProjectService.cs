namespace ConcreteIOT.Application.Services;

public interface IUserProjectService
{
    Task<bool> AddVisitorToProject(Guid projectId, string email);
}