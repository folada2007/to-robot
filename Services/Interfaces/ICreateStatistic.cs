namespace HackM.Services.Interfaces
{
    public interface ICreateStatistic
    {
        Task CreateUserStatisticAsync(string UserId);
    }
}
