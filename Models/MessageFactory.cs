using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class MessageFactory:IMessageFactory
    {
        public RpsViewModel messageFactory(string Message,string ComputerMove, int HeartCount,int Streak) 
        {
            return new RpsViewModel
            {
                Streak = Streak,
                Message = Message,
                ComputerMove = ComputerMove,
                HeartCount = HeartCount
            };
        }

        public RpsViewModel messageFactory(int HeartCount)
        {
            return new RpsViewModel
            {
                HeartCount = HeartCount
            };
        }
    }
}
