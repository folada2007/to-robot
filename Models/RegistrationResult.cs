using Microsoft.AspNetCore.Identity;

namespace HackM.Models
{
    public class RegistrationResult
    {
        public IdentityResult result { get; set; }
        public IdentityUser user { get; set; }
    }
}
