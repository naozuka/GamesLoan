using System.Threading.Tasks;

namespace GamesLoan.Core.Interfaces
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
         Task<T> Add(T entity);
         Task Update(T entity);
         Task Delete(T entity);
    }
}