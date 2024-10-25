using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class MessageFactory:IMessageFactory
    {
        private readonly IImageUrlRPS _imageUrlRPS;

        public MessageFactory(IImageUrlRPS imageUrlRPS)
        {
            _imageUrlRPS = imageUrlRPS;
        }

        public RpsViewModel CreateMessageFactory(string Message,string ComputerMove, int HeartCount,int Streak, bool IsWin, string UserMove) 
        {
            return new RpsViewModel
            {
                UserMoveUrl = _imageUrlRPS.GetImageUrl(UserMove),
                ComputerMoveUrl = _imageUrlRPS.GetImageUrl(ComputerMove),
                UserMove = UserMove,
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
