using System.Linq;
using GamesLoan.Core.Entities;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.UnitTests.Core.Entities.LoginTests
{    
    public class AddGame
    {
        [Fact]       
        public void AddGameAndCheckFirstAdded()
        {
            var login = new LoginBuilder().Build();
            var game = new GameBuilder().Build();            

            login.AddGame(game.Name);

            var first = login.Games.Single();
            Assert.Equal(game.Name, first.Name);            
        }
    }
}