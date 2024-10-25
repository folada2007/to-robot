using HackM.Models;
namespace HackM.Services.Interfaces
{
    public interface IMessageFactory
    {
        RpsViewModel CreateMessageFactory(string Message, string ComputerMove, int HeartCount, int Streak, bool IsWin,string UserMove);
        RpsViewModel CreateMessageFactory(int HeartCount);
    }
}
