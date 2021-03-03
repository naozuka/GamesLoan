using System.Linq;
using GamesLoan.Core.Entities;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.UnitTests.Core.Entities.LoginTests
{
    public class AddFriend
    {
        [Fact]       
        public void AddFriendAndCheckFirstAdded()
        {
            var login = new LoginBuilder().Build();
            var friend = new FriendBuilder().Build();            

            login.AddFriend(friend.Name, friend.PhoneNumber);

            var first = login.Friends.Single();
            Assert.Equal(friend.Name, first.Name);
            Assert.Equal(friend.PhoneNumber, first.PhoneNumber);
        }
    }
}