using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;
using System.Linq;

namespace Processo.WebApi.Service
{
    public class BeneficioService : IBeneficioService
    {
        private readonly IBeneficioRepository _beneficioRepository;
        public BeneficioService(IBeneficioRepository beneficioRepository)
        {
            _beneficioRepository = beneficioRepository;
        }

        public Model.Beneficio Cadastrar(Beneficio beneficio) 
        {
            _beneficioRepository.Save(beneficio);
            return _beneficioRepository.GetBeneficioMatricula(beneficio.Beneficiario.Matricula).FirstOrDefault();
        }

    }
}
