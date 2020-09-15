using Microsoft.AspNetCore.Mvc;

namespace DesafioApi2.Host.Controllers
{
    [Route("api")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        [Route("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok("https://github.com/88gm/desafioapi2 / https://github.com/88gm/desafioapi1");
        }
    }
}
