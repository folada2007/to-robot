using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HackM.Models
{
    public class AuthUser: IAuthUser
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthUser(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task AuthUserAsync(IdentityUser identityUser)
        {
            await _signInManager.SignInAsync(identityUser,isPersistent:true);
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginViewModel login) 
        {
           return await _signInManager.PasswordSignInAsync(login.name, login.password, login.RememberMe,lockoutOnFailure: false);
        }

        public async Task LogOutAsync() 
        {
           await _signInManager.SignOutAsync();
        }
    }
}
