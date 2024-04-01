using Microsoft.AspNetCore.Identity;

namespace Warehouse.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string surName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

    }
}
