using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesLoan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]        
        [AllowAnonymous]
        public ActionResult<string> Foo()
        {            
            return Ok("O que sabemos é uma gota. O que não sabemos é um oceano. (Dark)");
        }        
    }
}