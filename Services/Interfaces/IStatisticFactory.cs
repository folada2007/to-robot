using HackM.Models;

namespace HackM.Services.Interfaces
{
    public interface IStatisticFactory
    {
        StatisticViewModel CreateStatistic(StatisticDb UserStat);
    }
}
