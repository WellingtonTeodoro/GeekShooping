using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Model
{
    public class ApplicationUser : IdentityUser
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
    }
}
