using System;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.FriendServiceTests
{
    public class AddFriend
    {        
        private FriendDto _friendDto;

        public AddFriend()
        {
            var friend = new FriendBuilder().Build();
            _friendDto = new FriendDto(friend.Id, friend.Name, friend.PhoneNumber);
        }

        [Fact]
        public async Task AddFriendThatLoginDoesNotExists()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            var result = await friendService.Add(_friendDto, 1000);

            Assert.False(result.Success);            
        }

        [Fact]
        public async Task AddFriendSuccessfully()
        {            
            var login = new LoginBuilder().Build();
            var loginRepository = new LoginRepositoryBuilder().Build();
            
            await loginRepository.Add(login);
            var friendService = new FriendServiceBuilder(loginRepository).Build();
            var result = await friendService.Add(_friendDto, login.Id);

            Assert.True(result.Success);            
        }        
    }
}
    