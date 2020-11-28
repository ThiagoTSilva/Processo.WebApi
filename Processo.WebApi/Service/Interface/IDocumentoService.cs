using Processo.WebApi.Model;

namespace Processo.WebApi.Service.Interface
{
    public interface IDocumentoService
    {
        Documento AnexarArquivo(Documento documento);
        Documento GetDocumentoAnexado(int matricula);
    }
}
