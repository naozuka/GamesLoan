using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesLoan.Api.Controllers
{    
    public class LoginController : BaseApiController
    {        
        private readonly ILoginService _loginService;        
        
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
            //_hashService = hashService;
        }        

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenResult>> Authenticate(LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginService.Authenticate(login);
            
            return Ok(result);
        }

        [HttpPost("new")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> AddLogin(LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginService.Add(login);
            return Ok(result);
        }

        [HttpGet("refresh-token")]
        [Authorize]
        public async Task<ActionResult<TokenResult>> GetRefreshToken()
        {
            var loginId = await GetLoginId();
            var result = await _loginService.GetRefreshToken(loginId);
            return Ok(result);
            
        }
    }
}