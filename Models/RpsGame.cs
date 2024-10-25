using HackM.Services.Interfaces;
using HackM.Models.Enums;

namespace HackM.Models
{

    public class RpsGame: IRPSGame
    {
        public bool WinOrLose(RPSMove user, RPSMove computer) 
        {
            if (user == computer)
            {
                return true;
            }

            return (user == RPSMove.Scissors && computer == RPSMove.Paper ||
                user == RPSMove.Paper && computer == RPSMove.Rock ||
                user == RPSMove.Rock && computer == RPSMove.Scissors);
        }

        public RPSMove ComputerMove() 
        {
            var rnd = new Random();

            return (RPSMove)rnd.Next(0,3);
        }

    }
}
