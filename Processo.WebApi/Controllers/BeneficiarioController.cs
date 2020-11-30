using Microsoft.AspNetCore.Mvc;
using Processo.WebApi.Model;
using Processo.WebApi.Model.Dto;
using Processo.WebApi.Service.Interface;
using System;

namespace Processo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiarioController : ControllerBase
    {
        private readonly IBeneficiarioService _beneficiarioService;
        private readonly IBeneficioService _beneficioService;
        private readonly IDocumentoService _documentoService;
        public BeneficiarioController(IBeneficiarioService beneficiarioService, 
                                      IBeneficioService beneficioService,
                                      IDocumentoService documentoService) 
        {
            _beneficiarioService = beneficiarioService;
            _beneficioService = beneficioService;
            _documentoService = documentoService;
        }

        [HttpPost]
        public IActionResult Post(Beneficiario beneficio)
        {
            var beneficiario = _beneficiarioService.CadastarBeneficio(beneficio);
            
            return Created($"{Request.Path}/{beneficiario.Id}", beneficiario);
        }

        [HttpGet("{matricula}")]
        public IActionResult Get(string matricula)
        {
            var beneficiario = _beneficiarioService.GetBeneficiario(matricula);
            if (beneficiario == null)
                return NoContent();

            return Ok(beneficiario);
        }

        [HttpPost("~/api/cadastrar-beneficio")]
        public IActionResult Cadastrar(Beneficio beneficio)
        {
            var retorno = _beneficioService.Cadastrar(beneficio);
            if (retorno == null)
                return NoContent();

            return Created($"{Request.Path}/{retorno.Id}", retorno);
        }

        [HttpPost("~/api/anexar-documentos")]
        public IActionResult AnexarDocumentos(DocumentoDto documentoDto) 
        {
            var doc = _documentoService.AnexarArquivo(documentoDto);
            if (doc == null)
                return NoContent();

            return Created($"{Request.Path}/{doc.Id}", doc);

        }

        [HttpGet("~/api/{matricula}/buscar-documento")]
        public IActionResult GetAnexo(string matricula)
        {

            var anexo = _documentoService.GetDocumentoAnexado(matricula);
            string base64String = string.Empty;

            if (anexo != null) { 
                base64String = Convert.ToBase64String(anexo.Arquivo, 0, anexo.Arquivo.Length);
                base64String = "data:application / pdf; base64," + base64String;
             }
            
            if (anexo == null)
                return NoContent();

            return Ok(base64String);

        }
    }
}
