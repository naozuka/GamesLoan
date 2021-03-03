using GamesLoan.Core.DTO;

namespace GamesLoan.Core.Results
{
    public class GameResult : Result
    {
        public GameDto GameDto { get; set; }

        public GameResult(bool success, string message, GameDto gameDto = null) : base(success, message)
        {
            GameDto = gameDto;
        }
    }
}