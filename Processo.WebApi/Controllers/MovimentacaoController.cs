using Microsoft.AspNetCore.Mvc;
using Processo.WebApi.Model;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _service;
        public MovimentacaoController(IMovimentacaoService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(Movimentacao movimentacao) 
        {
            _service.CadastraMovimentacao(movimentacao);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movimentacaoLis = _service.GetMovimentacao();

            if (movimentacaoLis.Count == 0)
                return NoContent();

            return Ok();
        }

    }
}
