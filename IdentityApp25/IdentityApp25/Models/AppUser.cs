using Microsoft.AspNetCore.Identity;

namespace IdentityApp25.Models
{
    public class AppUser:IdentityUser
    {
        public int? Age { get; set; }
    }
}
