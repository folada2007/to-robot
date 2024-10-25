using HackM.Models.Enums;

namespace HackM.Services.Interfaces
{
    public interface IRPSGame
    {
        bool WinOrLose(RPSMove user,RPSMove computer);
        RPSMove ComputerMove();
    }
}
