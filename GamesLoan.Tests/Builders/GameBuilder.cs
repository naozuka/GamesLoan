using GamesLoan.Core.Entities;

namespace GamesLoan.Tests.Builders
{
    public class GameBuilder
    {
        private Game _game;
        private string _gameName = "Final Fantasy Tactics";       

        public GameBuilder()
        {
            _game = new Game(_gameName);
        }

        public Game Build()
        {
            return _game;
        }
    }
}