namespace GamesLoan.Core.DTO
{
    public class GameLoanDto
    {
        public int GameId { get; set; }
        public int FriendId { get; set; }

        public GameLoanDto(int gameId, int friendId)
        {
            GameId = gameId;
            FriendId = friendId;
        }
    }
}