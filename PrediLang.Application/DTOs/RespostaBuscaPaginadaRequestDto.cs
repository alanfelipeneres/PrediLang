using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.DTOs
{
    public class RespostaBuscaPaginadaRequestDto
    {
        public int idResposta { get; set; }
        public int idTemplate { get; set; }
        public string descricao { get; set; }
        public string usuario { get; set; }
        public string dataRegistro { get; set; }
    }
}
