using HackM.Models;
using HackM.Models.Enums;
using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace HackM.Controllers
{
    [Authorize]
    public class PlayController : Controller
    {
        private readonly IGameValid _gameValid;
        private readonly IStatistics _statistics;
        private readonly IGameService _gameService;

        public PlayController(
            IGameService gameService,
            IGameValid gameValid,
            IStatistics statistics)
        {
            _gameService = gameService;
            _gameValid = gameValid;
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
            (int?, RpsViewModel) HeartCount = _gameService.HeartInit();
                
            return View(HeartCount.Item2);
        }

        public IActionResult DifficultyMode() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult DifficultyMode(string difficulty)
        {
            _gameService.SetDifficultyMode(difficulty);

            return RedirectToAction("RPS");
        }

        [HttpPost]
        public async Task<IActionResult> RPS(string playerMove)
        {
            if (!Enum.TryParse<RPSMove>(playerMove, true, out RPSMove user)) 
            {
                return Content("Эту ошибку невозможно получить если у тебя это вышло ты бог");
            }

            var difficulty = HttpContext.Session.GetString("difficulty");

            if (difficulty == null) 
            {
                return RedirectToAction("DifficultyMode");
            }

            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ComputerMove = _gameService.ComputerMove();

            var IsWin = _gameService.IsWin();

            var result = _gameService.CreateStreak(user, ComputerMove);


            switch (result) 
            {
                case true:
                     _gameService.UpdateStreak();

                    if (IsWin) 
                    {
                        await _statistics.AddWin(id);
                    }
                    break;

                case false:
                    _gameService.LoseHandler();
                    break;
            }

            if (!_gameService.IsAlive())
            {
                await _statistics.AddLoseAsync(id);
            }

            var stateGame = _gameService.StateGame();

            var MessageForUSer = _gameService.CreateMessageFactory(result ? "+1 streak":"-1 hp", ComputerMove.ToString(), stateGame.heart, stateGame.streak, IsWin);

            return View(MessageForUSer);

        }

        public IActionResult Reset() 
        {
            HttpContext.Session.Remove("Heart");
            HttpContext.Session.Remove("Streak");
            _gameService.ResetHeart();
            return RedirectToAction("RPS");
        }
    }
}
