using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HackM.Models
{
    public class CreateUser:ICreateUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICreateStatistic _addStatistic;

        public CreateUser(UserManager<IdentityUser> userManager, ICreateStatistic addStatistic)
        {
            _addStatistic = addStatistic;
            _userManager = userManager;
        }

        public async Task<RegistrationResult> CreateUserAsync(RegistrViewModel registr) 
        {
            var User = new IdentityUser { UserName = registr.Name, Email = registr.Email };
            var Result = await _userManager.CreateAsync(User,registr.Password);

            if (Result.Succeeded) 
            {
                await _addStatistic.CreateUserStatisticAsync(User.Id);
            }

            return new RegistrationResult
            {
                user = Result.Succeeded ? User : null,
                result = Result
            };
        }
    }
}
