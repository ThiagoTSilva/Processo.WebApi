using Microsoft.AspNetCore.Mvc;
using Processo.WebApi.Model;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiarioController : ControllerBase
    {
        private readonly IBeneficiarioService _beneficiarioservice;
        private readonly IBeneficioService _beneficioService;
        private readonly IDocumentoService _documentoService;
        public BeneficiarioController(IBeneficiarioService beneficiarioservice, 
                                      IBeneficioService beneficioService,
                                      IDocumentoService documentoService) 
        {
            _beneficiarioservice = beneficiarioservice;
            _beneficioService = beneficioService;
            _documentoService = documentoService;
        }

        [HttpPost]
        public IActionResult Post(Beneficiario beneficio)
        {
            var beneficiario = _beneficiarioservice.CadastarBeneficio(beneficio);
            
            return Created($"{Request.Path}/{beneficiario.Id}", beneficiario);
        }

        [HttpGet]
        public IActionResult Get(int matricula)
        {
            var beneficiario = _beneficiarioservice.GetBeneficiario(matricula);
            if (beneficiario.Id == 0)
                return NoContent();

            return Ok(beneficiario);
        }

        [HttpPost("~/api/cadastrar-beneficio")]
        public IActionResult Cadastrar(Model.Beneficio beneficio)
        {
            var retorno = _beneficioService.Cadastrar(beneficio);
            if (retorno.Id == 0)
                return NoContent();

            return Created($"{Request.Path}/{retorno.Id}", retorno);
        }

        [HttpPost("~/api/anexar-documentos")]
        public IActionResult AnexarDocumentos(Documento documento) 
        {
            var doc = _documentoService.AnexarArquivo(documento);
            if (doc.Id == 0)
                return NoContent();

            return Created($"{Request.Path}/{doc.Id}", doc);

        }

        [HttpGet("~/api/{matricula}/buscar-documento")]
        public IActionResult GetAnexo(int matricula)
        {
            var anexo = _documentoService.GetDocumentoAnexado(matricula);
            if (anexo.Id == 0)
                return NoContent();

            return Created($"{Request.Path}/{anexo.Id}", anexo);

        }
    }
}
