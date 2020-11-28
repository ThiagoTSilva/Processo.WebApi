using Processo.WebApi.Data;
using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Processo.WebApi.Repositories
{
    public class BeneficioRepository : BaseRepository<Model.Beneficio>, IBeneficioRepository
    {
        private ContextDb db;
        public BeneficioRepository(ContextDb context) : base(context)
        {
            db = context;
        }

        public IEnumerable<Model.Beneficio> GetBeneficioMatricula(int matricula) 
        {
            var beneficio = from b in db.Beneficios
                            where b.Beneficiario.Matricula == matricula
                            select b;

            return beneficio;
        }

    }
}
