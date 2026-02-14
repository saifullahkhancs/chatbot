using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using chatbot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _context;

    public UserRoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
    }

    public List<UserRole> GetAll()
    {
        return _context.UserRoles.ToList();
    }

    public async Task<UserRole?> GetByIdAsync(Guid userId, Guid roleId)
    {
        return await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }

    public async Task DeleteAsync(Guid userId, Guid roleId)
    {
        var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
        if (userRole == null) return;

        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }

    public List<UserRole> GetByUserId(Guid userId)
    {
        return _context.UserRoles.Where(ur => ur.UserId == userId).ToList();
    }
}
