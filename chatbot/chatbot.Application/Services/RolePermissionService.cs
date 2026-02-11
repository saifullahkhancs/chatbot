using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;

namespace chatbot.Application.Services;

public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _repository;

    public RolePermissionService(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(RolePermission rolePermission)
    {
        await _repository.AddAsync(rolePermission);
    }

    public List<RolePermission> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<RolePermission?> GetByIdAsync(Guid roleId, Guid permissionId)
    {
        return await _repository.GetByIdAsync(roleId, permissionId);
    }

    public async Task DeleteAsync(Guid roleId, Guid permissionId)
    {
        await _repository.DeleteAsync(roleId, permissionId);
    }
}
