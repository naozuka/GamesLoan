using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Interfaces
{
    public interface ILoginService
    {        
        Task<Result> Add(LoginDto login);
        Task<TokenResult> Authenticate(LoginDto loginDto);
        Task<TokenResult> GetRefreshToken(int loginId);        
    }
}