using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Processo.WebApi.Model.Dto
{
    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Orgao { get; set; }
        public string Matricula { get; set; }
        public string DescricaoTipoBeneficio { get; set; }

    }
}
