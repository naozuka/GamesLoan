using GamesLoan.Infra.Services;
using GamesLoan.Tests.Builders;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GamesLoan.Tests.UnitTests.Infra.HashTests
{
    public class HashPassword
    {
        [Theory]
        [InlineData("Test6548", "4FIlL9ImGgDs9L8Fabn7bPX2y+Y8pszf4n44ImWUnTY=")]
        [InlineData("123456", "yly8fh3c3PDTzZCIqsRCbY4aIegA7Gea57nzdeLZYIY=")]
        [InlineData("onlyletters", "oO4qvGSbOeYmYtIrLY3EXWMA+JnRIN3xhMEsK77XALk=")]
        [InlineData("*Str0ngPa$$w0rdITh1nk!", "wlqpM1tE5uloCrHq1pPbjoWZ5u50EZvaBOocdK1Ff0E=")]	        
        
        public void HashPasswordAndCheck(string inputPassword, string expectedHash)
        {
            var configuration = new AppConfigurationBuilder().Build();
            var hashService = new HashService(configuration);
            var hashedPassword = hashService.Hash(inputPassword);

            Assert.Equal(hashedPassword, expectedHash);
        }
    }
}