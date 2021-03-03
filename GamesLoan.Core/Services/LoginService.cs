using System;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public LoginService(ILoginRepository loginRepository, 
            IHashService hashService,
            ITokenService tokenService)
        {
            _loginRepository = loginRepository;
            _hashService = hashService;
            _tokenService = tokenService;
        }
        
        public async Task<Result> Add(LoginDto loginDto)
        {
            var login = await _loginRepository.GetByEmail(loginDto.Email);

            try
            {
                if (login != null)
                    return new Result(false, "This email already exists");

                await _loginRepository.Add(new Login(loginDto.Email, _hashService.Hash(loginDto.Password)));

                return new Result(true, "Login created");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }        

        public async Task<TokenResult> GetRefreshToken(int loginId)
        {
            var login = await _loginRepository.GetById(loginId);

            try
            {
                if (login == null)
                    return new TokenResult(false, "This email does not exists");                

                string token = _tokenService.GenerateToken(login.Id, login.Email);
                return new TokenResult(true, "Token generated", token);
            }
            catch (Exception exception)
            {
                return new TokenResult(false, exception.Message);
            }
        }

        public async Task<TokenResult> Authenticate(LoginDto loginDto)
        {
            var login = await _loginRepository.GetByEmail(loginDto.Email);

            try
            {
                if (login == null)
                    return new TokenResult(false, "This email does not exists");

                if (login.Password != _hashService.Hash(loginDto.Password))
                    return new TokenResult(false, "Invalid password");

                string token = _tokenService.GenerateToken(login.Id, login.Email);
                return new TokenResult(true, "Authenticated", token);
            }
            catch (Exception exception)
            {
                return new TokenResult(false, exception.Message);
            }
        }        
    }
}