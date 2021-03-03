using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Tests.Builders;
using Xunit;

namespace GamesLoan.Tests.IntegrationTests.Services.LoginServiceTests
{
    public class AuthenticateLogin
    {
        private LoginDto _loginDto;

        public AuthenticateLogin()
        {   
            var login = new LoginBuilder().Build();
            _loginDto = new LoginDto(login.Email, login.Password);
        }

        [Fact]
        public async Task LoginThatNotExists()
        {            
            var loginRepository = new LoginRepositoryBuilder().Build();
            var loginService = new LoginServiceBuilder(loginRepository).Build(); 
            
            var result = await loginService.Authenticate(_loginDto);
            
            Assert.False(result.Success);
        }

        [Fact]
        public async Task LoginWithInvalidPassword()
        {
            var loginRepository = new LoginRepositoryBuilder().Build();
            var loginService = new LoginServiceBuilder(loginRepository).Build(); 
            await loginService.Add(_loginDto);
            
            var loginWithWrongPassword = new LoginDto(_loginDto.Email, "invalidPassword");
            var result = await loginService.Authenticate(loginWithWrongPassword);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task AuthenticateLoginSuccessfully()
        {            
            var loginRepository = new LoginRepositoryBuilder().Build();
            var loginService = new LoginServiceBuilder(loginRepository).Build(); 
            await loginService.Add(_loginDto);
            
            var result = await loginService.Authenticate(_loginDto);
            System.Console.WriteLine("Success: {0}", result.Success);
            
            Assert.True(result.Success);
        }
    }
}