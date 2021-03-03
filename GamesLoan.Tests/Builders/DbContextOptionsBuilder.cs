using GamesLoan.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GamesLoan.Tests.Builders
{
    public class AppDbContextOptionsBuilder
    {
        private DbContextOptions<AppDbContext> _dbContextOptions;

        public AppDbContextOptionsBuilder()
        {
            _dbContextOptions = CreateNewContextOptions();
        }

        private DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestGamesLoanDb")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            return options;
        }

        public DbContextOptions<AppDbContext> Build()
        {
            return _dbContextOptions;
        }
    }    
}