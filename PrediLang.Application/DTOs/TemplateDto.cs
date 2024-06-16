using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrediLang.Application.DTOs
{
    public class TemplateDto
    {
        public int IdTemplate { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTime DataRegistro { get; set; }

        [JsonIgnore]
        public ICollection<Resposta> Respostas { get; set; }
        [JsonIgnore]
        public ICollection<Complemento> Complementos { get; set; }
    }
}
