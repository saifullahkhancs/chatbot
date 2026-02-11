using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;

namespace chatbot.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Role role)
    {
        role.Id = Guid.NewGuid();
        await _repository.AddAsync(role);
    }

    public List<Role> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Role role)
    {
        await _repository.UpdateAsync(role);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
