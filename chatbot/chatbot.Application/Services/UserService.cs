using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;

namespace chatbot.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(User user)
    {
        user.Id = Guid.NewGuid();
        await _repository.AddAsync(user);
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task UpdateAsync(User user)
    {
        await _repository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
