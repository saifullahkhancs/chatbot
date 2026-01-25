using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using chatbot.Infrastructure.Data;

namespace chatbot.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
