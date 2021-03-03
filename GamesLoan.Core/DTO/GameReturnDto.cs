namespace GamesLoan.Core.DTO
{
    public class GameReturnDto
    {
        public int GameId { get; set; }

        public GameReturnDto(int gameId)
        {
            GameId = gameId;
        }
    }
}