using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;
using GamesLoan.Infra.Data.Repositories;

namespace GamesLoan.Tests.Builders
{
    public class LoginRepositoryBuilder
    {
        private ILoginRepository _loginRepository;

        public LoginRepositoryBuilder()
        {
            var dbOptions = new AppDbContextOptionsBuilder().Build();
            var context = new AppDbContext(dbOptions);
            _loginRepository = new LoginRepository(context);            
        }

        public ILoginRepository Build()
        {
            return _loginRepository;
        }        
    }
}