using System.Threading.Tasks;
using GamesLoan.Core.Entities;

namespace GamesLoan.Core.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {         
        Task<Login> GetById(int id);
        Task<Login> GetByEmail(string email);
    }
}