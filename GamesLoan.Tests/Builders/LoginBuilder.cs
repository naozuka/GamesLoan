using GamesLoan.Core.Entities;

namespace GamesLoan.Tests.Builders
{
    public class LoginBuilder
    {        
        private Login _login;
        private string _email = "naozuka@izusoftware.com";
        private string _password = "Naozuka*123";        
        
        public LoginBuilder()
        {
            _login = new Login(_email, _password);
        }

        public Login Build()
        {
            return _login;
        }

        public Login BuildWithGameAndFriend()
        {            
            var game = new GameBuilder().Build();
            var friend = new FriendBuilder().Build();

            _login.AddGame(game.Name);
            _login.AddFriend(friend.Name, friend.PhoneNumber);

            return _login;
        }
    }
}