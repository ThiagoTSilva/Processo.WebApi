using Processo.WebApi.Data;
using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Processo.WebApi.Repositories
{
    public class BeneficiarioRepository : BaseRepository<Beneficiario> , IBeneficiarioRepository
    {
        private readonly ContextDb db;
        public BeneficiarioRepository(ContextDb context) : base(context)
        {
            db = context;
        }

        public IEnumerable<Beneficiario> GetBeneficiario(int matricula)
        {
            var beneficiario = from b in db.Beneficiarios
                               where b.Matricula == matricula
                               select b;

            return beneficiario;
        }
    }
}
