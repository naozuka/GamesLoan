using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.FriendServiceTests
{
    public class DeleteFriend
    {
        private FriendDto _friendDto;

        public DeleteFriend()
        {     
            var friend = new FriendBuilder().Build();
            _friendDto = new FriendDto(friend.Id, friend.Name, friend.PhoneNumber);
        }        

        [Fact]
        public async Task DeleteFriendThatNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);            
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            var result = await friendService.Delete(1000, login.Id);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeleteFriendThatLoginNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);            
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            var result = await friendService.Delete(1000, 1000);

            Assert.False(result.Success);
        }        

        [Fact]
        public async Task DeleteFriendSuccessfully()
        {            
            const int expectedCount = 0;
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            await friendService.Add(_friendDto, login.Id);

            var insertedFriend = login.Friends.Single();
            var result = await friendService.Delete(insertedFriend.Id, login.Id);

            Assert.True(result.Success);
            Assert.Equal(login.Friends.Count, expectedCount);
        }
    }
}