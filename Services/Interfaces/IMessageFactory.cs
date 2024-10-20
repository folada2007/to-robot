using HackM.Models;
namespace HackM.Services.Interfaces
{
    public interface IMessageFactory
    {
        RpsViewModel messageFactory(string Message,string ComputerMove,int HeartCount,int Streak);
        RpsViewModel messageFactory(int HeartCount);
    }
}
