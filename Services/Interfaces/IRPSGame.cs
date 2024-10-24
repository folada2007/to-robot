using HackM.Models.Enums;

namespace HackM.Services.Interfaces
{
    public interface IRPSGame
    {
        bool CreateStreak(RPSMove user,RPSMove computer);
        RPSMove ComputerMove();
    }
}
