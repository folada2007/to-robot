using HackM.Models;
using HackM.Models.Enums;

namespace HackM.Services.Interfaces
{
    public interface IGameService
    {
        (int?, RpsViewModel) HeartInit();
        void SetDifficultyMode(string difficulty);
        DifficultyEnum GetDifficultyMode();
        void AddStreak();
        int GetStreak();
        void RemoveStreak();
        int GetHealth();
        void ResetHeart();
        void LoseHeart();
        RpsViewModel CreateMessageFactory(string Message, string ComputerMove, int HeartCount, int Streak, bool IsWin);
        bool IsAlive();
        bool CreateStreak(RPSMove User, RPSMove ComputerMove);
        RPSMove ComputerMove();
        bool IsWin();
        void UpdateStreak();
        void LoseHandler();
        (int heart, int streak) StateGame();
    }
}
