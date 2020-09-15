using DesafioApi2.Domain.Juros;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioApi2.Host.Controllers
{
    [Route("api/juros")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private IJurosService _jurosService;
        public JurosController 
        (
            IJurosService jurosService 
        )
        {
            _jurosService = jurosService ?? throw new ArgumentNullException(nameof(jurosService));
        }

        [HttpGet]
        [Route("calculajuros/{vlInicial:decimal}/{tempo:int}")]
        public IActionResult CalculaJuros(decimal vlInicial, int tempo)
        {
            return Ok(_jurosService.CalculaJuros(vlInicial, tempo));
        }
    }
}