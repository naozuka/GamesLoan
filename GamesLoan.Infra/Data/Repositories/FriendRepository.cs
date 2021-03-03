using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;

namespace GamesLoan.Infra.Data.Repositories
{
    public class FriendRepository : EfRepository<Friend>, IFriendRepository
    {
        public FriendRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}