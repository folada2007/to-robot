using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class MessageFactory:IMessageFactory
    {
        public RpsViewModel CreateMessageFactory(string Message,string ComputerMove, int HeartCount,int Streak, bool IsWin) 
        {
            return new RpsViewModel
            {
                UserWin = IsWin,
                Streak = Streak,
                Message = Message,
                ComputerMove = ComputerMove,
                HeartCount = HeartCount
            };
        }

        public RpsViewModel CreateMessageFactory(int HeartCount)
        {
            return new RpsViewModel
            {
                HeartCount = HeartCount
            };
        }
    }
}
