using System.Collections.Generic;
using GamesLoan.Core.DTO;

namespace GamesLoan.Core.Results
{
    public class FriendListResult : Result
    {
        public IEnumerable<FriendDto> FriendsDto { get; set; }

        public FriendListResult(bool success, string message, IEnumerable<FriendDto> friendsDto = null) : base(success, message)
        {
            FriendsDto = friendsDto;
        }
    }
}