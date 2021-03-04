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
            return Ok("\"What we know is a drop. What we don't know, is an ocean\". (Dark)");
        }        
    }
}