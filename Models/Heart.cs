using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class Heart: IHealth
    {
        public int Hearts { get; private set; } = 3;
        public int Streak { get; private set; } = 0;

        public void AddStreak() 
        {
            Streak++;
        }
        public void RemoveStreak() 
        {
            if (Streak > 0) 
            {
                Streak = 0;
            }
        }

        public int GetStreak()
        {
            return Streak; 
        }

        public void LoseHeart() 
        {

            if (Hearts > 0) 
            {
                Hearts--;
            }
        }

        public bool IsAlive() 
        {
            return Hearts > 0;
        }

        public int GetHealth()
        {
            return Hearts;
        }

        public void ResetHeart() 
        {
            Hearts = 3;
        }
    }
}
