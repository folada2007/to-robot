using HackM.Models;
using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HackM.Controllers
{
    [Authorize]
    public class PlayController : Controller
    {
        private readonly IHealth _health;

        private readonly IGameValid _gameValid;

        private readonly IRPSGame _RPSGame;

        private readonly IMessageFactory _messageFactory;

        private readonly IStatistics _statistics;

        public PlayController(IGameValid gameValid, IHealth health, IRPSGame rPSGame, IMessageFactory messageFactory, IStatistics statistics)
        {
            _messageFactory = messageFactory;
            _gameValid = gameValid;
            _health = health;
            _RPSGame = rPSGame;
            _statistics = statistics;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PLay()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Play(string gameName) 
        {
            var Game = await _gameValid.IsValid(gameName);

            if (Game)
            {
                return RedirectToAction(gameName);
            }

            return View();
        }

        public IActionResult RPS() 
        {
            int? saveHeart = HttpContext.Session.GetInt32("Heart");

            if (saveHeart == null) 
            {
                saveHeart = _health.GetHealth();
                HttpContext.Session.SetInt32("Heart", saveHeart.Value);
            }

            var HeartCount = _messageFactory.messageFactory(saveHeart.Value);

            return View(HeartCount);
        }

        [HttpPost]
        public async Task<IActionResult> RPS(string playerMove)
        {
            
            if (Enum.TryParse<RPSMove>(playerMove, true, out RPSMove user)) 
            {
                int heart = HttpContext.Session.GetInt32("Heart") ?? _health.GetHealth();

                var ComputerMove = _RPSGame.ComputerMove();
                
                var result = _RPSGame.IsWin(user, ComputerMove) ? "Win" : "Lose";

                if (result == "Lose") 
                {
                   
                    _health.LoseHeart();
                    heart = _health.GetHealth();
                    HttpContext.Session.SetInt32("Heart", heart);
                }
                
                if (!_health.IsAlive())
                {
                    string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    await _statistics.AddLoseAsync(id);

                    return RedirectToAction("RPS");
                }

                var MessageForUSer = _messageFactory.messageFactory(result,ComputerMove.ToString(),heart);

                return View(MessageForUSer);
            }

            return Content("Эту ошибку невозможно получить если у тебя это вышло ты бог");
        }

        [HttpPost]
        public IActionResult Reset() 
        {
            HttpContext.Session.Remove("Heart");
            _health.ResetHeart();
            return RedirectToAction("RPS");
        }
    }
}
