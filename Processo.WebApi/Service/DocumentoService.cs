using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi.Service
{
    public class DocumentoService : IDocumentoService
    {
        private IDocumentoRepository _documentoRepository;
        public DocumentoService(IDocumentoRepository documentoRepository) 
        {
            _documentoRepository = documentoRepository;
        }

        public Documento AnexarArquivo(Documento documento)
        {
            Documento docBeneficiario = null;

            _documentoRepository.Save(documento);

             var doc = _documentoRepository.GetDocumentosAnexado(documento.Beneficiario.Matricula);

            foreach (var d in doc) 
            {
                docBeneficiario = new Documento
                {
                    Id = d.Id,
                    Arquivo = d.Arquivo,
                    Beneficiario = d.Beneficiario
                };
            }
            return docBeneficiario;
        }

        public Documento GetDocumentoAnexado(int matricula)
        {
            Documento doc = null;
            var anexo = _documentoRepository.GetDocumentosAnexado(matricula);
            foreach (var docAnexo in anexo) 
            {
                doc = new Documento
                {
                    Id = doc.Id,
                    Arquivo = doc.Arquivo,
                    Beneficiario = doc.Beneficiario
                };

            }

            return doc;
        }
    }
}
