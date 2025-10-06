using ConcreteIOT.Application.IRepository;
using ConcreteIOT.Application.Models;
using ConcreteIOT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcreteIOT.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null)
            return false;

        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null)
            return false;

        _context.Users.Remove(existingUser);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistByEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}