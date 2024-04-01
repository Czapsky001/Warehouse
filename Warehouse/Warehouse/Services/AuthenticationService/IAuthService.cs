using Warehouse.Authentication;

namespace Warehouse.Services.AuthenticationService
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(string email, string username, string password, string role);
        Task<AuthResult> LoginAsync(string email, string password);
    }
}
