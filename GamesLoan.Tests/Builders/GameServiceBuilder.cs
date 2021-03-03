using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Services;

namespace GamesLoan.Tests.Builders
{
    public class GameServiceBuilder
    {
        private IGameService _gameService;        

        public GameServiceBuilder(ILoginRepository loginRepository)
        {            
            _gameService = new GameService(loginRepository);
        }

        public IGameService Build()
        {
            return _gameService;
        }
    }
}