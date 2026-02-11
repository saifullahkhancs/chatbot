using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using chatbot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Infrastructure.Repositories;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AppDbContext _context;

    public RolePermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(RolePermission rolePermission)
    {
        _context.RolePermissions.Add(rolePermission);
        await _context.SaveChangesAsync();
    }

    public List<RolePermission> GetAll()
    {
        return _context.RolePermissions.ToList();
    }

    public async Task<RolePermission?> GetByIdAsync(Guid roleId, Guid permissionId)
    {
        return await _context.RolePermissions.FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
    }

    public async Task DeleteAsync(Guid roleId, Guid permissionId)
    {
        var rolePermission = _context.RolePermissions.FirstOrDefault(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        if (rolePermission == null) return;

        _context.RolePermissions.Remove(rolePermission);
        await _context.SaveChangesAsync();
    }
}
