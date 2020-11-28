using Processo.WebApi.Data;
using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Processo.WebApi.Repositories
{
    public class DocumentoRepository : BaseRepository<Documento>, IDocumentoRepository
    {
        private ContextDb db;
        public DocumentoRepository(ContextDb context) : base(context) 
        {
            db = context;
        }

        public IEnumerable<Documento> GetDocumentosAnexado(int matricula)
        {
            var doc = from d in db.Documentos
                      where d.Beneficiario.Matricula == matricula
                      select d;

            return doc;
        }
    }
}
