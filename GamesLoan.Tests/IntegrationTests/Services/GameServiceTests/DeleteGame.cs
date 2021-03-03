using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.GameServiceTests
{
    public class DeleteGame
    {
        private GameDto _gameDto;

        public DeleteGame()
        {     
            var game = new GameBuilder().Build();
            _gameDto = new GameDto(game.Id, game.Name);
        }        

        [Fact]
        public async Task DeleteGameThatNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);            
            var gameService = new GameServiceBuilder(loginRepository).Build();
            
            var result = await gameService.Delete(1000, login.Id);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeleteGameThatLoginNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);
            var gameService = new GameServiceBuilder(loginRepository).Build();
            
            var result = await gameService.Delete(1000, 1000);

            Assert.False(result.Success);
        }        

        [Fact]
        public async Task DeleteGameSuccessfully()
        {            
            const int expectedCount = 0;
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var gameService = new GameServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            await gameService.Add(_gameDto, login.Id);

            var insertedGame = login.Games.Single();
            var result = await gameService.Delete(insertedGame.Id, login.Id);

            Assert.True(result.Success);
            Assert.Equal(login.Games.Count, expectedCount);
        }
    }
}