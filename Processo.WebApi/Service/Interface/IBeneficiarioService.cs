using Processo.WebApi.Model;

namespace Processo.WebApi.Service.Interface
{
    public interface IBeneficiarioService
    {
        Beneficiario CadastarBeneficio(Beneficiario beneficio);
        Beneficiario GetBeneficiario(string matricula);
    }
}
