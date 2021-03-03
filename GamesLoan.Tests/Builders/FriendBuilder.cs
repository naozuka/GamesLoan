using GamesLoan.Core.Entities;

namespace GamesLoan.Tests.Builders
{
    public class FriendBuilder
    {               
        private Friend _friend;
        private string _friendName = "Ruanzito";
        private string _phoneNumber = "3333-5555";

        public FriendBuilder()
        {
            _friend = new Friend(_friendName, _phoneNumber);
        }

        public Friend Build()
        {
            return _friend;
        }
    }
}