using Processo.WebApi.Model;
using Processo.WebApi.Model.Dto;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Processo.WebApi.Service
{
    public class DocumentoService : IDocumentoService
    {
        private IDocumentoRepository _documentoRepository;
        public DocumentoService(IDocumentoRepository documentoRepository) 
        {
            _documentoRepository = documentoRepository;
        }

        public Documento AnexarArquivo(DocumentoDto documentoDto)
        {
            //Limpar o Hash enviado
            var data = new Regex(@"^data:application/pdf;base64,").Replace(documentoDto.Arquivo, "");

            //Gerar um array de Bytes
            var arquivo = Convert.FromBase64String(data);
 
            var documento = new Documento
            {
                Arquivo = arquivo,
                Categoria = documentoDto.Categoria,
                Matricula = documentoDto.Matricula                
            };

            _documentoRepository.Save(documento);

             var doc = _documentoRepository.GetDocumentosAnexado(documento.Matricula);
            return this.Converte(doc);
        }

        public Documento GetDocumentoAnexado(string matricula)
        {
            var anexo = _documentoRepository.GetDocumentosAnexado(matricula);
            return this.Converte(anexo);
        }

        private Documento Converte(IEnumerable<Documento> anexo) 
        {
            Documento documento = null;
            foreach (var docAnexo in anexo)
            {
                documento = new Documento
                {
                    Id = docAnexo.Id,
                    Arquivo = docAnexo.Arquivo,
                    Matricula = docAnexo.Matricula
                };
             
            }
            return documento;
        }
    }
}
