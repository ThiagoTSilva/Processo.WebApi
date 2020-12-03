using Processo.WebApi.Model;
using Processo.WebApi.Model.Dto;

namespace Processo.WebApi.Service.Interface
{
    public interface IBeneficiarioService
    {
       // Beneficiario CadastarBeneficio(Beneficiario beneficio);
        ColaboradorDto GetBeneficiario(string matricula);
    }
}
