using Processo.WebApi.Data;
using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;

namespace Processo.WebApi.Repositories
{
    public class MovimentacaoRepository  : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(ContextDb context) : base(context) 
        {

        }
    }
}
