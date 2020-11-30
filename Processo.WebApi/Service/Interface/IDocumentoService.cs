using Processo.WebApi.Model;
using Processo.WebApi.Model.Dto;

namespace Processo.WebApi.Service.Interface
{
    public interface IDocumentoService
    {
        Documento AnexarArquivo(DocumentoDto documentoDto);
        Documento GetDocumentoAnexado(string matricula);
    }
}
