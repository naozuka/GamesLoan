using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.FriendServiceTests
{
    public class UpdateFriend
    {        
        private FriendDto _friendDto;

        public UpdateFriend()
        {     
            var friend = new FriendBuilder().Build();
            _friendDto = new FriendDto(friend.Id, friend.Name, friend.PhoneNumber);
        }        

        [Fact]
        public async Task UpdateFriendThatNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);            
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            var result = await friendService.Update(_friendDto, login.Id);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task UpdateFriendThatLoginNotExists()
        {
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var friendService = new FriendServiceBuilder(loginRepository).Build();

            await loginRepository.Add(login);
            await friendService.Add(_friendDto, login.Id);
            var result = await friendService.Update(_friendDto, 1000);

            Assert.False(result.Success);
        }        

        [Fact]
        public async Task UpdateFriendSuccessfully()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            
            await loginRepository.Add(login);            
            var result = await friendService.Add(_friendDto, login.Id);

            Assert.True(result.Success);

            var insertedFriend = login.Friends.Single();
            
            Assert.Equal(insertedFriend.Name, _friendDto.Name);
            Assert.Equal(insertedFriend.PhoneNumber, _friendDto.PhoneNumber);
        }        
    }
}