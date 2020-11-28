using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Processo.WebApi.Model
{
    public class Movimentacao
    {
        public int  Id{ get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public Usuario Usuario { get; set; }
        public string Acao { get; set; }

    }
}
