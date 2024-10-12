using HackM.Models;
using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HackM.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICreateUser _createUser;
        private readonly IAuthUser _authUser;

        public AuthController(ICreateUser createUser, IAuthUser authUser)
        {
            _createUser = createUser;
            _authUser = authUser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut() 
        {
           await _authUser.LogOutAsync();
           return RedirectToAction("Index","Auth");
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login) 
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated) 
                {
                    ModelState.AddModelError(string.Empty, "Your is Authenticated pls exit hz");
                    return View();
                }

               var result = await _authUser.PasswordSignInAsync(login);

                if (result.Succeeded)
                {
                    Console.WriteLine($"Аутентификация успешна: {User.Identity.Name}");
                }

                Console.WriteLine($"Неуспешно:{result}");
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrViewModel registr) 
        {
            if (ModelState.IsValid)
            {
                var registrationResult = await _createUser.CreateUserAsync(registr);

                if (registrationResult.result.Succeeded)
                {
                    await _authUser.AuthUserAsync(registrationResult.user);
                    return RedirectToAction("Index","Home");
                }

                foreach (var error in registrationResult.result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Index", registr);
        }
    }
}
