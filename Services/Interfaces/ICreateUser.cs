using HackM.Models;
using Microsoft.AspNetCore.Identity;

namespace HackM.Services.Interfaces
{
    public interface ICreateUser
    {
        Task<RegistrationResult> CreateUserAsync(RegistrViewModel registr);
    }
}
