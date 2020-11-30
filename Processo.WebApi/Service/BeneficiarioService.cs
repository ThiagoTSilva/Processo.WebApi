using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;
using System.Linq;

namespace Processo.WebApi.Service
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioService(IBeneficiarioRepository beneficiarioRepository) 
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        public Beneficiario CadastarBeneficio(Beneficiario beneficiario)
        {
            _beneficiarioRepository.Save(beneficiario);

            return _beneficiarioRepository.GetBeneficiario(beneficiario.Matricula).FirstOrDefault();
        }

        public Beneficiario GetBeneficiario(string matricula)
        {
            return _beneficiarioRepository.GetBeneficiario(matricula).FirstOrDefault();
        }
    }
}
