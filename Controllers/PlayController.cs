using HackM.Models.Enums;
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
        private readonly IGameValid _gameValid; //well well well zamena na servic igr
        private readonly IRPSGame _RPSGame; //well well well zamena na servic igr
        private readonly IMessageFactory _messageFactory;
        private readonly IStatistics _statistics;
        private readonly IDifficultyMode _mode;

        public PlayController(
            IDifficultyMode mode,
            IGameValid gameValid, 
            IHealth health, 
            IRPSGame rPSGame,
            IMessageFactory messageFactory,
            IStatistics statistics)
        {
            _mode = mode;
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

        public IActionResult DifficultyMode() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult DifficultyMode(string difficulty)
        {
            _mode.SetDifficultyMode(difficulty);

            return RedirectToAction("RPS");
        }

        [HttpPost]
        public async Task<IActionResult> RPS(string playerMove)
        {
            if (!Enum.TryParse<RPSMove>(playerMove, true, out RPSMove user)) 
            {
                return Content("Эту ошибку невозможно получить если у тебя это вышло ты бог");
            }

            var DifficultyMode = HttpContext.Session.GetString("difficulty");

            if (DifficultyMode == null) 
            {
                return RedirectToAction("DifficultyMode");
            }

            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ComputerMove = _RPSGame.ComputerMove();

            var result = _RPSGame.AddPoint(user, ComputerMove) ? "+1 point" : "-1 heart";

            switch (result)
            {
                case "+1 point":
                    await AddPoint(id);
                    if (_mode.IsWin()) 
                    {
                        return Content("im gay");
                    }
                    break;

                case "-1 heart":
                    LoseHandler();
                    break;
            }

            if (!_health.IsAlive())
            {
                await _statistics.AddLoseAsync(id);
                return RedirectToAction("RPS");
            }

            var stateGame = StateGame();

            var MessageForUSer = _messageFactory.messageFactory(result, ComputerMove.ToString(), stateGame.heart, stateGame.streak);

            return View(MessageForUSer);

        }

        private (int heart, int streak) StateGame() 
        {
            int heart = HttpContext.Session.GetInt32("Heart") ?? _health.GetHealth();
            int streak = HttpContext.Session.GetInt32("Streak") ?? _health.GetStreak();

            return (heart,streak);
        }


        private async Task AddPoint(string id) 
        {
            await _statistics.AddWinAsync(id);
            _health.AddStreak();
            int streakCount = _health.GetStreak();
            HttpContext.Session.SetInt32("Streak", streakCount);
        }

        private void LoseHandler() 
        {
            _health.RemoveStreak();
            int streakCount = _health.GetStreak();
            HttpContext.Session.SetInt32("Streak", streakCount);

            _health.LoseHeart();
            int heart = _health.GetHealth();
            HttpContext.Session.SetInt32("Heart", heart);
        }

        public IActionResult Reset() 
        {
            HttpContext.Session.Remove("Heart");
            _health.ResetHeart();
            return RedirectToAction("RPS");
        }
    }
}
