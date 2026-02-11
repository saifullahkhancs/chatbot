using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;

namespace chatbot.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _repository;

    public PermissionService(IPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Permission permission)
    {
        permission.Id = Guid.NewGuid();
        await _repository.AddAsync(permission);
    }

    public List<Permission> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Permission?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Permission permission)
    {
        await _repository.UpdateAsync(permission);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
