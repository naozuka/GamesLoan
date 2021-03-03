using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Services;

namespace GamesLoan.Tests.Builders
{
    public class FriendServiceBuilder
    {        
        private IFriendService _friendService;        

        public FriendServiceBuilder(ILoginRepository loginRepository)
        {            
            _friendService = new FriendService(loginRepository);
        }

        public IFriendService Build()
        {
            return _friendService;
        }
    }
}