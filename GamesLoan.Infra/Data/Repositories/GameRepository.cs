using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;

namespace GamesLoan.Infra.Data.Repositories
{
    public class GameRepository : EfRepository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext dbContext) : base(dbContext)
        {
        }        
    }
}