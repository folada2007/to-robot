using Microsoft.AspNetCore.Mvc;

namespace HackM.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PLay()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Play(string gameName) 
        {
            return View();
        }
    }
}
