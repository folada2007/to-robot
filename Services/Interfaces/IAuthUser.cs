using HackM.Models;
using Microsoft.AspNetCore.Identity;

namespace HackM.Services.Interfaces
{
    public interface IAuthUser
    {
        Task AuthUserAsync(IdentityUser identityUser);
        Task<SignInResult> PasswordSignInAsync(LoginViewModel login);
        Task LogOutAsync();
    }
}
