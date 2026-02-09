using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    List<User> GetAll();
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
