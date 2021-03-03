using GamesLoan.Core.Entities;
using GamesLoan.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamesLoan.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Login>(new LoginConfiguration().Configure);
            builder.Entity<Game>(new GameConfiguration().Configure);
            builder.Entity<Friend>(new FriendConfiguration().Configure);        
        }
    }
}