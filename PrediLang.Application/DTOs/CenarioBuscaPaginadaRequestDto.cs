using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.DTOs
{
    public class CenarioBuscaPaginadaRequestDto
    {
        public int? idCenario { get; set; }
        public int? idTemplate { get; set; }
        public string? pergunta { get; set; }
        public string? resposta { get; set; }
        public string? usuario { get; set; }
        public string? dataRegistroInicio { get; set; }
        public string? dataRegistroFim { get; set; }
    }
}
