using System.ComponentModel.DataAnnotations;

namespace HackM.Models
{
    public class LoginViewModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string email { get; set; }
        public bool RememberMe { get; set; }
    }
}
