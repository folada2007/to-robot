using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class MessageFactory:IMessageFactory
    {
        public RpsViewModel messageFactory(string Message,string ComputerMove, int HeartCount) 
        {
            return new RpsViewModel
            {
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
