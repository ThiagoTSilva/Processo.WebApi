using Microsoft.AspNetCore.Mvc;
using Processo.WebApi.Model;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var retorno = _service.Cadastrar(usuario);

            if (retorno.Id == 0)
                return NoContent();

            return Created($"{Request.Path}/{retorno.Id}", retorno);
        }

        [HttpGet]
        public IActionResult Get(int id, string senha)
        {
            var beneficiario = _service.ValidarUsuario(id, senha);
            if (beneficiario.Id == 0)
                return NoContent();

            return Ok(beneficiario);
        }

    }
}
