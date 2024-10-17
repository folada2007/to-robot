using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class Heart: IHealth
    {
        public int Hearts { get; private set; } = 3;


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
