using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.GameServiceTests
{
    public class UpdateGame
    {
        private GameDto _gameDto;

        public UpdateGame()
        {     
            var game = new GameBuilder().Build();
            _gameDto = new GameDto(game.Id, game.Name);
        }        

        [Fact]
        public async Task UpdateGameThatNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);            
            var gameService = new GameServiceBuilder(loginRepository).Build();
            var result = await gameService.Update(_gameDto, login.Id);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task UpdateGameThatLoginNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var gameService = new GameServiceBuilder(loginRepository).Build();

            await loginRepository.Add(login);
            await gameService.Add(_gameDto, login.Id);
            var result = await gameService.Update(_gameDto, 1000);

            Assert.False(result.Success);
        }        

        [Fact]
        public async Task UpdateGameSuccessfully()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var gameService = new GameServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            var result = await gameService.Add(_gameDto, login.Id);

            Assert.True(result.Success);

            var insertedGame = login.Games.Single();
            
            Assert.Equal(insertedGame.Name, _gameDto.Name);            
        }
    }
}