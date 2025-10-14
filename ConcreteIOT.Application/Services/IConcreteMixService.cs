using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.Services;

public interface IConcreteMixService
{
    Task<bool> CreateAsync(Guid projectId, ConcreteMix mix);
    Task<ConcreteMix?> GetByIdAsync(Guid projectId, Guid id);
    Task<IEnumerable<ConcreteMix>> GetAllByProjectAsync(Guid projectId);
    Task<bool> UpdateAsync(Guid projectId, Guid id, ConcreteMix mix);
    Task<bool> DeleteAsync(Guid projectId, Guid id);
}