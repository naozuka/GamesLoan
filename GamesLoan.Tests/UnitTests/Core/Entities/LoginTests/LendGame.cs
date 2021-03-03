using GamesLoan.Core.Entities;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.UnitTests.Core.Entities.LoginTests
{
    public class LendGame
    {
        int _invalidGameId = 1000;
        int _invalidFriendId = 1000;
        int _validGameId = 0;
        int _validFriendId = 0;        

        [Fact]
        public void LendGameThatNotExists()
        {            
            var login = new LoginBuilder().BuildWithGameAndFriend();

            Assert.False(login.LendGame(_invalidGameId, _invalidFriendId));
        }

        [Fact]
        public void LendGameToNonexistentFriend()
        {
            var login = new LoginBuilder().BuildWithGameAndFriend();

            Assert.False(login.LendGame(_validGameId, _invalidFriendId));
        }

        [Fact]
        public void LendGameToExistentGameAndExistentFriend()
        {
            var login = new LoginBuilder().BuildWithGameAndFriend();

            Assert.True(login.LendGame(_validGameId, _validFriendId));
        }
    }
}