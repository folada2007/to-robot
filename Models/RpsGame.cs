using HackM.Services.Interfaces;

namespace HackM.Models
{
    public enum RPSMove
    {
        Rock,
        Paper,
        Scissors
    }

    public class RpsGame: IRPSGame
    {
        public bool IsWin(RPSMove user, RPSMove computer) 
        {
            if (user == computer)
            {
                return true;
            }

            else if (user == RPSMove.Scissors && computer == RPSMove.Paper ||
                user == RPSMove.Paper && computer == RPSMove.Rock ||
                user == RPSMove.Rock && computer == RPSMove.Scissors) 
            {
                return true;
            }

            return false;
        }

        public RPSMove ComputerMove() 
        {
            var rnd = new Random();

            return (RPSMove)rnd.Next(0,3);
        }

    }
}
