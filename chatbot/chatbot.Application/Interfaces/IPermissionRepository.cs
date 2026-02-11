using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IPermissionRepository
{
    Task AddAsync(Permission permission);
    List<Permission> GetAll();
    Task<Permission?> GetByIdAsync(Guid id);
    Task UpdateAsync(Permission permission);
    Task DeleteAsync(Guid id);
}
