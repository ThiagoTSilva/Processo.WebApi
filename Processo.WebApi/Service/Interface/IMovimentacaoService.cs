using Processo.WebApi.Model;
using System.Collections.Generic;

namespace Processo.WebApi.Service.Interface
{
    public interface IMovimentacaoService
    {
        void CadastraMovimentacao(Movimentacao movimentacao);
        List<Movimentacao> GetMovimentacao();
    }
}
