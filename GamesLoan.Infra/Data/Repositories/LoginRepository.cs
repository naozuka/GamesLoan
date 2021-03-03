using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GamesLoan.Infra.Data.Repositories
{
    public class LoginRepository : EfRepository<Login>, ILoginRepository
    {
        public LoginRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Login> GetById(int id)
        {
            return await _dbContext.Set<Login>()                
                .Include(f => f.Friends)
                .Include(g => g.Games)
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Login> GetByEmail(string email)
        {
            var login = await _dbContext.Set<Login>()
                .Where(w => w.Email == email)
                .FirstOrDefaultAsync();

            return login;
        }
    }
}