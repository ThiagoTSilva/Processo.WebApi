using Processo.WebApi.Model;
using System;
using System.Collections.Generic;

namespace Processo.WebApi.Repositories.Interface
{
    public interface IDocumentoRepository : IBaseRepository<Documento>, IDisposable
    {
        IEnumerable<Documento> GetDocumentosAnexado(string matricula);
    }
}
