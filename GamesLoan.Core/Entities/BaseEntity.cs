using GamesLoan.Core.Interfaces;

namespace GamesLoan.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }        
    }
}