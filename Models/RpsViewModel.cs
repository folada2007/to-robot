namespace HackM.Models
{
    public class RpsViewModel
    {
        public string UserMoveUrl { get; set;}
        public string ComputerMoveUrl { get; set;}
        public string Message { get; set; }
        public string ComputerMove { get; set; }
        public string UserMove { get; set; }
        public int HeartCount { get; set; }
        public int Streak {  get; set; }
        public bool UserWin { get; set; }
    }
}
