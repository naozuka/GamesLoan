using System.IO;
using Microsoft.Extensions.Configuration;

namespace GamesLoan.Tests.Builders
{
    public class AppConfigurationBuilder    
    {        
        IConfiguration _configuration;

        public AppConfigurationBuilder()
        {
            _configuration = new ConfigurationBuilder()                                
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();    
        }

        public IConfiguration Build()
        {
            return _configuration;
        }
    }    
}