using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Interfaces
{
    public interface IGameService
    {
        Task<GameListResult> GetAll(int loginId);
        Task<GameResult> GetById(int gameId, int loginId);
        Task<Result> Add(GameDto gameDto, int loginId);
        Task<Result> Update(GameDto gameDto, int loginId);
        Task<Result> Delete(int gameId, int loginId);
        Task<Result> Lend(GameLoanDto gameLoanDto, int loginId);
        Task<Result> Return(GameReturnDto gameReturnDto, int loginId);
    }
}