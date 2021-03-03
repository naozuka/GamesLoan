using GamesLoan.Core.Interfaces;

namespace GamesLoan.Core.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } 
        public int LoginId { get; private set; }
        public int? FriendId { get; private set; }        

        public Game(string name)
        {
            Name = name;
        }

        public bool LendTo(int friendId)
        {
            if (FriendId != null)
                return false;

            FriendId = friendId;
            return true;
        }

        public bool GetBack()
        {
            if (FriendId == null)
                return false;

            FriendId = null;
            return true;
        }
    }
}