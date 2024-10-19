using HackM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HackM.Models
{
    public class CreateStatistic:ICreateStatistic
    {
        private readonly ApplicationDbContext _context;

        public CreateStatistic(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task CreateUserStatisticAsync(string UserId) 
        {
            var Stat = new StaticDb { Id = UserId };

            _context.staticsDb.Add(Stat);

            await _context.SaveChangesAsync();
        }
    }
}
