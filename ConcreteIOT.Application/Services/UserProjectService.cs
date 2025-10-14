using ConcreteIOT.Application.IRepository;

namespace ConcreteIOT.Application.Services;

public class UserProjectService : IUserProjectService
{
    private readonly IUserProjectRepository _userProjectRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public UserProjectService(IUserProjectRepository userProjectRepository, IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _userProjectRepository = userProjectRepository;
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> AddVisitorToProject(Guid projectId, string email)
    {
        var projectExists = await _projectRepository.GetByIdAsync(projectId);
        if (projectExists is null)
            return false;
        
        var userExists = await _userRepository.ExistByEmail(email);
        if (!userExists)
            return false;
        
        return await _userProjectRepository.AddVisitorToProject(projectId, email);
    }
}