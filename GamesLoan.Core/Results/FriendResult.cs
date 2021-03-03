using GamesLoan.Core.DTO;

namespace GamesLoan.Core.Results
{
    public class FriendResult : Result
    {
        public FriendDto FriendDto { get; set; }

        public FriendResult(bool success, string message, FriendDto friendDto = null) : base(success, message)
        {
            FriendDto = friendDto;
        }
    }
}