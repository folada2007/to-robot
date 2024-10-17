using HackM.Models;
namespace HackM.Services.Interfaces
{
    public interface IMessageFactory
    {
        RpsViewModel messageFactory(string Message,string ComputerMove,int HeartCount);
        RpsViewModel messageFactory(int HeartCount);
    }
}
