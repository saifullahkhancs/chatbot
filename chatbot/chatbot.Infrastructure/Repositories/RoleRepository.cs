using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using chatbot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
    }

    public List<Role> GetAll()
    {
        return _context.Roles.ToList();
    }

    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = _context.Roles.FirstOrDefault(r => r.Id == id);
        if (role == null) return;

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }
}
