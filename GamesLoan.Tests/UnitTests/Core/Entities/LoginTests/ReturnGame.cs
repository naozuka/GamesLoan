using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.UnitTests.Core.Entities.LoginTests
{
    public class ReturnGame
    {
        int _invalidGameId = 1000;        
        int _validGameId = 0;        
        int _validFriendId = 0;        
        
        [Fact]
        public void ReturnGameThatNotExists()
        {
            var login = new LoginBuilder().BuildWithGameAndFriend();

            Assert.False(login.ReturnGame(_invalidGameId));
        }

        [Fact]
        public void ReturnGameThatExistsAndIsNotLent()
        {
            var login = new LoginBuilder().BuildWithGameAndFriend();

            Assert.False(login.ReturnGame(_validGameId));
        }

        [Fact]
        public void ReturnGameThatExistsAndIsLent()
        {
            var login = new LoginBuilder().BuildWithGameAndFriend();
            
            login.LendGame(_validGameId, _validFriendId);

            Assert.True(login.ReturnGame(_validGameId));
        }
    }
}