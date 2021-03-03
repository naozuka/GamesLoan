using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Interfaces
{
    public interface IFriendService
    {
        Task<FriendListResult> GetAll(int loginId);
        Task<FriendResult> GetById(int friendId, int loginId);
        Task<Result> Add(FriendDto friendDto, int loginId);
        Task<Result> Update(FriendDto friendDto, int loginId);
        Task<Result> Delete(int friendId, int loginId);
    }
}