public interface IAuthService
{
    Task Register(string name, string email, string password);
    Task<string> Login(string email, string password);
}
