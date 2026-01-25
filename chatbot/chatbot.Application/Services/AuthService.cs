using chatbot.Domain.Entities;
using chatbot.Application.Interfaces;

public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _hasher;

    public AuthService(
        IUserRepository users,
        ITokenService tokenService,
        IPasswordHasher hasher)
    {
        _users = users;
        _tokenService = tokenService;
        _hasher = hasher;
    }

    public async Task Register(string name, string email, string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            PasswordHash = _hasher.Hash(password)
        };

        await _users.AddAsync(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _users.GetByEmailAsync(email)
                   ?? throw new Exception("Invalid credentials");

        if (!_hasher.Verify(user.PasswordHash, password))
            throw new Exception("Invalid credentials");

        return _tokenService.GenerateToken(user);
    }
}
