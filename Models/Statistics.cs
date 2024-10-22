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

        public async Task DropStat() 
        {
            var StatList = await _context.staticsDb.ToListAsync();

            foreach (var i in StatList) 
            {
                i.WinCount = 0;
                i.LoseCount = 0;
            }

            await _context.SaveChangesAsync();
        }

        private async Task<StatisticDb> FoundUserIdAsync(string Id) 
        {
           return await _context.staticsDb.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task AddWinAsync(string Id) 
        {
            var UserStat = await FoundUserIdAsync(Id);

            if (UserStat == null)
            {
                Console.WriteLine("Эй разраб ебанный я там не нашел такого пользователя ");
            }
            else 
            {
                UserStat.WinCount++;
                _context.SaveChanges();
            }

        }

        public async Task<StatisticViewModel> GetStatisticAsync(string Id)
        {
            var UserStat = await FoundUserIdAsync(Id);

            return _statisticFactory.CreateStatistic(UserStat);
        }

        public async Task AddLoseAsync(string Id) 
        {
            var UserStat = await FoundUserIdAsync(Id);

            if (UserStat == null)
            {
                Console.WriteLine("Эй разраб ебанный я там не нашел такого пользователя ");
            }
            else 
            {
                UserStat.LoseCount++;
                await _context.SaveChangesAsync();
            }
        }
    }
}
