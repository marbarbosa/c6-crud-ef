using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        //'4:44
        [HttpGet("health-check")]
        public IActionResult Get() 
        { 
            return Ok( 
                new 
                {
                    versao = 1.0 
                }
            ); 
        }
    }
}
