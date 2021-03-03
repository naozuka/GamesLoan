using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.GameServiceTests
{
    public class AddGame
    {
        private GameDto _gameDto;

        public AddGame()
        {
            var game = new GameBuilder().Build();
            _gameDto = new GameDto(game.Id, game.Name);
        }

        [Fact]
        public async Task AddGameThatLoginDoesNotExists()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);
            var gameService = new GameServiceBuilder(loginRepository).Build();
            var result = await gameService.Add(_gameDto, 1000);

            Assert.False(result.Success);            
        }

        [Fact]
        public async Task AddGameSuccessfully()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);
            var gameService = new GameServiceBuilder(loginRepository).Build();
            var result = await gameService.Add(_gameDto, login.Id);

            Assert.True(result.Success);            
        } 
    }
}