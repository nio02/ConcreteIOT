using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public class ConcreteMixService : IConcreteMixService
{
    private readonly IConcreteMixRepository _concreteMixRepository;
    private readonly IProjectRepository _projectRepository;

    public ConcreteMixService(IConcreteMixRepository concreteMixRepository, IProjectRepository projectRepository)
    {
        _concreteMixRepository = concreteMixRepository;
        _projectRepository = projectRepository;
    }

    public async Task<bool> CreateAsync(Guid projectId, ConcreteMix mix)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project is null)
            return false;

        mix.ProjectId = project.Id;
        
        return await _concreteMixRepository.CreateAsync(mix);
    }

    public async Task<ConcreteMix?> GetByIdAsync(Guid projectId, Guid id)
    {
        var mix = await _concreteMixRepository.GetByIdAsync(id);
        if (mix is null || mix.ProjectId != projectId)
            return null;
        
        return mix;
    }

    public async Task<IEnumerable<ConcreteMix>> GetAllByProjectAsync(Guid projectId)
    {
        return await _concreteMixRepository.GetAllByProjectAsync(projectId);
    }

    public async Task<bool> UpdateAsync(Guid projectId, Guid id, ConcreteMix mix)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project is null)
            return false;
        
        return await _concreteMixRepository.UpdateAsync(id, mix);
    }

    public async Task<bool> DeleteAsync(Guid projectId, Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project is null)
            return false;
        
        return await _concreteMixRepository.DeleteAsync(id);
    }
}