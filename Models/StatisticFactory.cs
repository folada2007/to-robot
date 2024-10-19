using HackM.Services.Interfaces;

namespace HackM.Models
{
    public class StatisticFactory:IStatisticFactory
    {
        public StatisticViewModel CreateStatistic(StaticDb UserStat) 
        {
            return new StatisticViewModel 
            {
                LoseCount = UserStat.LoseCount,
                WinCount = UserStat.WinCount,
            };
        }
    }
}
