using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.IRepository;

public interface IConcreteMixRepository
{
    Task<bool> CreateAsync(ConcreteMix mix);
    Task<ConcreteMix?> GetByIdAsync(Guid id);
    Task<IEnumerable<ConcreteMix>> GetAllByProjectAsync(Guid projectId);
    Task<bool> UpdateAsync(Guid id, ConcreteMix mix);
    Task<bool> DeleteAsync(Guid id);
}