using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IRoleRepository
{
    Task AddAsync(Role role);
    List<Role> GetAll();
    Task<Role?> GetByIdAsync(Guid id);
    Task UpdateAsync(Role role);
    Task DeleteAsync(Guid id);
}
