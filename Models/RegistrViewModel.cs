using System.ComponentModel.DataAnnotations;

namespace HackM.Models
{
    public class RegistrViewModel
    {
        [Required(ErrorMessage = "enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "enter the password")]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [Required(ErrorMessage = "confirm it")]
        public string Confirmpassword { get; set; }

    }
}
