using Microsoft.AspNetCore.Identity;

namespace Demo.Authentcation
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
