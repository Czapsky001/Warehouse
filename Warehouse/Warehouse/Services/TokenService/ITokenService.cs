using Microsoft.AspNetCore.Identity;

namespace Warehouse.Services.TokenService;

public interface ITokenService
{
    string CreateToken(IdentityUser user, string role);
}
