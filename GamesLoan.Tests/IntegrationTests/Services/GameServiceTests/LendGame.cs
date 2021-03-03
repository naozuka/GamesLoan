using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.GameServiceTests
{
    public class LendGame
    {
        private GameDto _gameDto;
        private FriendDto _friendDto;

        public LendGame()
        {     
            var game = new GameBuilder().Build();
            _gameDto = new GameDto(game.Id, game.Name);

            var friend = new FriendBuilder().Build();
            _friendDto = new FriendDto(friend.Id, friend.Name, friend.PhoneNumber);
        } 

        [Fact]
        public async Task LendGameSuccessfully()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var gameService = new GameServiceBuilder(loginRepository).Build();
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            await gameService.Add(_gameDto, login.Id);
            await friendService.Add(_friendDto, login.Id);
            
            var insertedGame = login.Games.Single();
            var insertedFriend = login.Friends.Single();

            var gameLoanDto = new GameLoanDto(insertedGame.Id, insertedFriend.Id);            
            var result = await gameService.Lend(gameLoanDto, login.Id);

            Assert.True(result.Success);            
            Assert.Equal(insertedGame.FriendId, insertedFriend.Id);
        }

        [Fact]
        public async Task DontLendGameThatIsAlreadyLent()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var gameService = new GameServiceBuilder(loginRepository).Build();
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            await gameService.Add(_gameDto, login.Id);
            await friendService.Add(_friendDto, login.Id);
            
            var insertedGame = login.Games.Single();
            var insertedFriend = login.Friends.Single();

            var gameLoanDto = new GameLoanDto(insertedGame.Id, insertedFriend.Id);            
            await gameService.Lend(gameLoanDto, login.Id);

            // Try to lend again
            var result = await gameService.Lend(gameLoanDto, login.Id);

            Assert.False(result.Success);
        }
    }
}