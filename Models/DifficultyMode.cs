using HackM.Models.Enums;
using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class DifficultyMode: IDifficultyMode
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DifficultyMode(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }

        public bool IsWin()
        {
            var session = _contextAccessor.HttpContext.Session;
            string? difficulty = session.GetString("difficulty");

            if (Enum.TryParse<DifficultyEnum>(difficulty, true, out DifficultyEnum difficultyResult))
            {
                int difficultyCount = GetDifficultyCount(difficultyResult);
                int streak = session.GetInt32("Streak") ?? 0;

                return streak >= difficultyCount;
            }

            return false;
        }

        public DifficultyEnum GetDifficultyMode() 
        {
            var difficultyMode = _contextAccessor.HttpContext.Session.GetString("difficulty");

            if (Enum.TryParse<DifficultyEnum>(difficultyMode,true,out DifficultyEnum result)) 
            {
                return result;
            }
            return DifficultyEnum.Easy; 
        }

        public void SetDifficultyMode(string difficulty) 
        {
            _contextAccessor.HttpContext.Session.SetString("difficulty", difficulty);
        }

        public int GetDifficultyCount(DifficultyEnum difficulty) 
        {
            return (int)difficulty;
        }
    }
}
