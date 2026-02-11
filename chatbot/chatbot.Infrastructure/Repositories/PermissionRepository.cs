using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using chatbot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Infrastructure.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Permission permission)
    {
        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
    }

    public List<Permission> GetAll()
    {
        return _context.Permissions.ToList();
    }

    public async Task<Permission?> GetByIdAsync(Guid id)
    {
        return await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Permission permission)
    {
        _context.Permissions.Update(permission);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var permission = _context.Permissions.FirstOrDefault(p => p.Id == id);
        if (permission == null) return;

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync();
    }
}
