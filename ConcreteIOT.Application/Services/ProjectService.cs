using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserProjectRepository _userProjectRepository;

    public ProjectService(IProjectRepository projectRepository, IUserProjectRepository userProjectRepository)
    {
        _projectRepository = projectRepository;
        _userProjectRepository = userProjectRepository;
    }


    public async Task<bool> CreateAsync(Project project, Guid userId)
    {
        var newProject = await _projectRepository.CreateAsync(project);

        var userProject = new UserProject
        {
            ProjectId = project.Id,
            UserId = userId,
            Role = ProjectRole.OWNER
        };

        await _userProjectRepository.CreateAsync(userProject);

        return newProject;
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Project project)
    {
        return await _projectRepository.UpdateAsync(id, project);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var projectDeleted = await _projectRepository.DeleteAsync(id);
        
        await _userProjectRepository.DeleteByProjectAsync(id);
        
        return projectDeleted;
    }
}