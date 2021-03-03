using GamesLoan.Core.Interfaces;

namespace GamesLoan.Tests.Services
{
    // This class is just for tests. There is not need to use token on service tests

    public class FakeTokenService : ITokenService
    {
        public string GenerateToken(int loginId, string email)
        {
            return "FakeTokenThatWillNotBeUsed";
        }
    }
}