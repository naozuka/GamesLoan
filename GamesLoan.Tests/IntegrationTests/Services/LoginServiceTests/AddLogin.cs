using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Services;
using GamesLoan.Infra.Data.Context;
using GamesLoan.Infra.Data.Repositories;
using GamesLoan.Infra.Services;
using GamesLoan.Tests.Builders;
using GamesLoan.Tests.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace GamesLoan.Tests.IntegrationTests.Services.LoginServiceTests
{
    public class AddLogin
    {        
        private LoginDto _loginDto;        

        public AddLogin()
        {   
            var login = new LoginBuilder().Build();
            _loginDto = new LoginDto(login.Email, login.Password);
        }

        [Fact]
        public async Task AddLoginSuccessfully()
        {      
            var loginRepository = new LoginRepositoryBuilder().Build();
            var loginService = new LoginServiceBuilder(loginRepository).Build();            

            var result = await loginService.Add(_loginDto);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task DontAddLoginWithDuplicateEmail()
        {
            var loginRepository = new LoginRepositoryBuilder().Build();
            var loginService = new LoginServiceBuilder(loginRepository).Build();             
            await loginService.Add(_loginDto);

            // Try to insert with same login
            var result = await loginService.Add(_loginDto);

            Assert.False(result.Success);
        }
    }
}