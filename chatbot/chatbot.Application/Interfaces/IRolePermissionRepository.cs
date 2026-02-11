using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IRolePermissionRepository
{
    Task AddAsync(RolePermission rolePermission);
    List<RolePermission> GetAll();
    Task<RolePermission?> GetByIdAsync(Guid roleId, Guid permissionId);
    Task DeleteAsync(Guid roleId, Guid permissionId);
}
