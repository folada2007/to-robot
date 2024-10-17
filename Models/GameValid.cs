using HackM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HackM.Models
{
    public class GameValid:IGameValid
    {
        private readonly ApplicationDbContext _context;

        public GameValid(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> IsValid(string nameGame) 
        {
            var game = await _context.gamesDb.FirstOrDefaultAsync(x => x.Name == nameGame);
            return game != null;
        }
    }
}
