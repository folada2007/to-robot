using HackM.Models;

namespace HackM.Services.Interfaces
{
    public interface IRPSGame
    {
        bool IsWin(RPSMove user,RPSMove computer);
        RPSMove ComputerMove();
    }
}
