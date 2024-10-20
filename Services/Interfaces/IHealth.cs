namespace HackM.Services.Interfaces
{
    public interface IHealth
    {
        void LoseHeart();
        bool IsAlive();
        int GetHealth();
        void ResetHeart();
        void AddStreak();
        void RemoveStreak();
        int GetStreak();
    }
}
