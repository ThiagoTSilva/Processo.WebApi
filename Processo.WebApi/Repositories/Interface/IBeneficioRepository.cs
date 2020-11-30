using Processo.WebApi.Model;
using System;
using System.Collections.Generic;

namespace Processo.WebApi.Repositories.Interface
{
    public interface IBeneficioRepository : IBaseRepository<Beneficio>, IDisposable
    {
        IEnumerable<Beneficio> GetBeneficioMatricula(string matricula);
    }
}
