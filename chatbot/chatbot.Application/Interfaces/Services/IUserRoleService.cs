using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IUserRoleService
{
    Task AddAsync(UserRole userRole);
    List<UserRole> GetAll();
    Task<UserRole?> GetByIdAsync(Guid userId, Guid roleId);
    Task DeleteAsync(Guid userId, Guid roleId);
}
