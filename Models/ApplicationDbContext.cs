﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackM.Models
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        :base(options)
        {

        }
        public DbSet<StatisticDb> staticsDb { get; set; }
        public DbSet<GameDb> gamesDb { get; set; }
    }
}
