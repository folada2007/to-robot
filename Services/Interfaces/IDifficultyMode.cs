using HackM.Models.Enums;

namespace HackM.Services.Interfaces
{
    public interface IDifficultyMode
    {
        DifficultyEnum GetDifficultyMode();
        void SetDifficultyMode(string difficulty);
        int GetDifficultyCount(DifficultyEnum difficulty);
        bool IsWin();
    }
}
