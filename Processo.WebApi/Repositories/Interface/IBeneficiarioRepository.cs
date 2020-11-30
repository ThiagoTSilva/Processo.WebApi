using Processo.WebApi.Model;
using System;
using System.Collections.Generic;

namespace Processo.WebApi.Repositories.Interface
{
    public interface IBeneficiarioRepository : IBaseRepository<Beneficiario>, IDisposable
    {
        IEnumerable<Beneficiario> GetBeneficiario(string matricula);
    }
}
