using HackM.Models;

namespace HackM.Services.Interfaces
{
    public interface IStatistics
    {
        Task AddLoseAsync(string Id);
        Task AddWinAsync(string Id);
        Task<StatisticViewModel> GetStatisticAsync(string Id);
        Task DropStat();
    }
}
