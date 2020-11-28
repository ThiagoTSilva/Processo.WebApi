using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;
using System.Collections.Generic;

namespace Processo.WebApi.Service
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository) 
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void CadastraMovimentacao(Movimentacao movimentacao)
        {
            _movimentacaoRepository.Save(movimentacao); 
        }

        public List<Movimentacao> GetMovimentacao()
        {
            List<Movimentacao> mList = new List<Movimentacao>();

           var list = _movimentacaoRepository.FindAll();

            foreach (var lista in list) 
            {
                var movimentacao = new Movimentacao
                {
                    Id = lista.Id,
                    Usuario = lista.Usuario,
                    Origem = lista.Origem,
                    Destino = lista.Destino
                };

                mList.Add(movimentacao);
            }

            return mList;
        }
    }
}
