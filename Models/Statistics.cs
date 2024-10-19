using HackM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HackM.Models
{
    public class Statistics: IStatistics
    {
        private readonly ApplicationDbContext _context;
        private readonly IStatisticFactory _statisticFactory;

        public Statistics(ApplicationDbContext context,IStatisticFactory statisticFactory) 
        {
            _statisticFactory = statisticFactory;
            _context = context;
        }

        public async Task<StatisticViewModel> GetStatisticAsync(string Id)
        {
            var UserStat = await _context.staticsDb.FirstOrDefaultAsync(c => c.Id == Id);

            return _statisticFactory.CreateStatistic(UserStat);
        }

        public async Task AddLoseAsync(string Id) 
        {
            var UserStat = await _context.staticsDb.FirstOrDefaultAsync(c => c.Id == Id);

            if (UserStat == null)
            {
                Console.WriteLine("User not found");
            }
            else 
            {
                UserStat.LoseCount++;
                await _context.SaveChangesAsync();
            }
        }
    }
}
