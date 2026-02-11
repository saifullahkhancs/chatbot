using chatbot.Domain.Entities;

namespace chatbot.Application.Interfaces;

public interface IUserService
{
    Task AddAsync(User user);
    List<User> GetAll();
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
}
