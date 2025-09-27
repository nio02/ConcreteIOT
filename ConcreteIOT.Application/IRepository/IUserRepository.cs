using ConcreteIOT.Application.Models;

namespace ConcreteIOT.Application.IRepository;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> UpdateAsync(Guid id, User user);
    Task<bool> DeleteAsync(Guid id);
}