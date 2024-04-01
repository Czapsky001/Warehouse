using Warehouse.Model;

namespace Warehouse.Services.TokenService
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
