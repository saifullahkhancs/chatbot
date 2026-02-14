using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;

namespace chatbot.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _repository.AddAsync(userRole);
    }

    public List<UserRole> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<UserRole?> GetByIdAsync(Guid userId, Guid roleId)
    {
        return await _repository.GetByIdAsync(userId, roleId);
    }

    public async Task DeleteAsync(Guid userId, Guid roleId)
    {
        await _repository.DeleteAsync(userId, roleId);
    }

    public List<UserRole> GetByUserId(Guid userId)
    {
        return _repository.GetByUserId(userId);
    }
}
