using Processo.WebApi.Model;
using Processo.WebApi.Model.Dto;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;
using System.Linq;

namespace Processo.WebApi.Service
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        private readonly IBeneficioRepository _beneficioRepository;

        public BeneficiarioService(IBeneficiarioRepository beneficiarioRepository,
                                   IBeneficioRepository beneficioRepository ) 
        {
            _beneficiarioRepository = beneficiarioRepository;
            _beneficioRepository = beneficioRepository;
        }

        //public Beneficio CadastarBeneficio(Beneficiario beneficiario)
        //{
        //    _beneficiarioRepository.Save(beneficiario);

        //    return _beneficiarioRepository.GetBeneficiario(beneficiario.Matricula).FirstOrDefault();
        //}

        public ColaboradorDto GetBeneficiario(string matricula)
        {
            var beneficiario = _beneficiarioRepository.GetBeneficiario(matricula).FirstOrDefault();
            var beneficio = _beneficioRepository.GetBeneficioIdBeneficiario(beneficiario.Id).FirstOrDefault();

            var rBeneficiario = new ColaboradorDto
            {
                Id = beneficiario.Id,
                Nome = beneficiario.Nome,
                Cpf = beneficiario.Cpf,
                Matricula = beneficiario.Matricula,
                Orgao = beneficiario.Orgao,
                DescricaoTipoBeneficio = beneficio.DescricaoTipoBeneficio
            };

            return rBeneficiario;
        }
    }
}
