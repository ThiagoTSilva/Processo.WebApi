using System;

namespace Processo.WebApi.Model
{
    public class Movimentacao
    {
        public Movimentacao()
        {
            DataTramitacao = DateTime.Now;
        }

        public int  Id{ get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int UsuarioId { get; set; }
        public string Acao { get; set; }
        public DateTime DataTramitacao { get; set; }

    }
}
