using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesLoan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private async Task<JwtSecurityToken> GetTokenSecurity()
        {
            var handler = new JwtSecurityTokenHandler();
            var token = await HttpContext.GetTokenAsync("access_token");
            var tokenSecurity = handler.ReadToken(token) as JwtSecurityToken;
            return tokenSecurity;
        }

        protected async Task<int> GetLoginId()
        {
            var tokenSecurity = await GetTokenSecurity();
            return Convert.ToInt32(tokenSecurity.Claims.FirstOrDefault().Value);
        }

        protected async Task<string> GetLoginEmail()
        {            
            var tokenSecurity = await GetTokenSecurity();
            return tokenSecurity.Claims.FirstOrDefault(x => x.Type == "Email").Value;            
        }
    }    
}