using System.Collections.Generic;
using GamesLoan.Core.DTO;

namespace GamesLoan.Core.Results
{
    public class GameListResult : Result
    {
        public IEnumerable<GameDto> GamesDto { get; set; }

        public GameListResult(bool success, string message, IEnumerable<GameDto> gamesDto = null) : base(success, message)
        {
            GamesDto = gamesDto;
        }
    }
}