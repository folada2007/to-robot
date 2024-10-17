namespace HackM.Services.Interfaces
{
    public interface IGameValid
    {
        Task<bool> IsValid(string nameGame);
    }
}
