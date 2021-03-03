using System.Threading.Tasks;
using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GamesLoan.Infra.Data.Repositories
{
    public abstract class EfRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }        

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}