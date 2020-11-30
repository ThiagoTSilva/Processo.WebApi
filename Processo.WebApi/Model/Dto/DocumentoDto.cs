using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Processo.WebApi.Model.Dto
{
    public class DocumentoDto
    {
        public string Arquivo { get; set; }
        public string Matricula { get; set; }
        public string Categoria { get; set; }
    }
}
