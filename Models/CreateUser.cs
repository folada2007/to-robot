using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HackM.Models
{
    public class CreateUser:ICreateUser
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUser(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegistrationResult> CreateUserAsync(RegistrViewModel registr) 
        {
            var User = new IdentityUser { UserName = registr.Name, Email = registr.Email };
            var Result = await _userManager.CreateAsync(User,registr.Password);

            return new RegistrationResult
            {
                user = Result.Succeeded ? User : null,
                result = Result
            };


        }
    }
}
