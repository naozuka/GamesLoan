using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GamesLoan.Core.Entities
{
    public class Login : BaseEntity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        private readonly List<Game> _games = new List<Game>();
        public virtual IReadOnlyCollection<Game> Games => _games.AsReadOnly();

        private readonly List<Friend> _friends = new List<Friend>();
        public virtual IReadOnlyCollection<Friend> Friends => _friends.AsReadOnly();        

        public Login(string email, string password)
        {
            Email = email;
            Password = password;         
        }

        public void AddGame(string name)
        {
            _games.Add(new Game(name));            
        }

        public bool RemoveGame(Game game)
        {
            return _games.Remove(game);
        }

        public void AddFriend(string name, string phoneNumber)
        {
            _friends.Add(new Friend(name, phoneNumber));
        }        

        public bool RemoveFriend(Friend friend)
        {
            return _friends.Remove(friend);
        }

        public bool LendGame(int gameId, int friendId)
        {
            var game = Games.FirstOrDefault(x => x.Id == gameId);
            var friend = Friends.FirstOrDefault(x => x.Id == friendId);

            if (game == null || friend == null)
                return false;

            return game.LendTo(friendId);
        }

        public bool ReturnGame(int gameId)
        {
            var game = Games.FirstOrDefault(x => x.Id == gameId);

            if (game == null)
                return false;

            return game.GetBack();
        }
    }
}