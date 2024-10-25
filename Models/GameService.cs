using HackM.Models.Enums;
using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class GameService:IGameService
    {
        private readonly IHealth _health;
        private readonly IRPSGame _RPSGame;
        private readonly IDifficultyMode _mode;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMessageFactory _MessageFactory;

        public GameService(IMessageFactory MessageFactory, IHttpContextAccessor accessor,IHealth health,IRPSGame RPSGame,IDifficultyMode mode) 
        {
            _MessageFactory = MessageFactory;
            _accessor = accessor;
            _health = health;
            _mode = mode;
            _RPSGame = RPSGame;
        }

        public (int?,RpsViewModel) HeartInit() 
        {
            int? HeartCount = _accessor.HttpContext.Session.GetInt32("Heart");

            if (HeartCount is null) 
            {
                HeartCount = _health.GetHealth();

                _accessor.HttpContext.Session.SetInt32("Heart",HeartCount.Value);
            }

            var MessageHeartCount = _MessageFactory.CreateMessageFactory(HeartCount.Value);

            return (HeartCount,MessageHeartCount);
        }

        public void SetDifficultyMode(string difficulty) 
        {
            _mode.SetDifficultyMode(difficulty);
        }

        public DifficultyEnum GetDifficultyMode() 
        {
           return _mode.GetDifficultyMode();
        }

        public void AddStreak() 
        {
            _health.AddStreak();
        }

        public int GetStreak() 
        {
            return _health.GetStreak();
        }

        public void RemoveStreak() 
        {
            _health.RemoveStreak();
        }

        public int GetHealth() 
        {
            return _health.GetHealth();
        }

        public void ResetHeart() 
        {
            _health.ResetHeart();
        }

        public void LoseHeart() 
        {
            _health.LoseHeart();
        }

        public RpsViewModel CreateMessageFactory(string Message,string ComputerMove,int HeartCount,int Streak,bool IsWin, string UserMove) 
        {
            return _MessageFactory.CreateMessageFactory(Message,ComputerMove,HeartCount,Streak,IsWin, UserMove);
        }

        public bool IsAlive() 
        {
            return _health.IsAlive();
        }

        public bool WinOrLose(RPSMove User,RPSMove ComputerMove) 
        {
            return _RPSGame.WinOrLose(User, ComputerMove);
        }

        public RPSMove ComputerMove() 
        {
            return _RPSGame.ComputerMove();
        }

        public bool IsWin() 
        {
           return _mode.IsWin();
        }

        public void UpdateStreak()
        {
            AddStreak();
            int streakCount = GetStreak();
            _accessor.HttpContext.Session.SetInt32("Streak", streakCount);
        }

        public void LoseHandler() 
        {
            RemoveStreak();
            int streakCount = GetStreak();
            _accessor.HttpContext.Session.SetInt32("Streak", streakCount);

            LoseHeart();
            int heart = GetHealth();
            _accessor.HttpContext.Session.SetInt32("Heart", heart);
        }

        public (int heart, int streak) StateGame()
        {
            int heart = _accessor.HttpContext.Session.GetInt32("Heart") ?? GetHealth();
            int streak = _accessor.HttpContext.Session.GetInt32("Streak") ?? GetStreak();

            return (heart, streak);
        }
    }
}
