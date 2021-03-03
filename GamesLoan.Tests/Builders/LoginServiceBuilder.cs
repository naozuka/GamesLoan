using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Services;
using GamesLoan.Infra.Services;
using GamesLoan.Tests.Services;

namespace GamesLoan.Tests.Builders
{
    public class LoginServiceBuilder
    {
        private ILoginService _loginService;

        public LoginServiceBuilder(ILoginRepository loginRepository)
        {
            var configuration = new AppConfigurationBuilder().Build();
            var hashService = new HashService(configuration);
            var fakeTokenService = new FakeTokenService();
            _loginService = new LoginService(loginRepository, hashService, fakeTokenService);
        }

        public ILoginService Build()
        {
            return _loginService;
        }        
    }
}