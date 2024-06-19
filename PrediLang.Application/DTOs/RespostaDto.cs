using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrediLang.Application.DTOs
{
    public class RespostaDto
    {
        public int IdResposta { get; set; }
        public int IdTemplate { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTime? DataRegistro { get; set; }
        public string DataRegistroFormatada
        {
            get
            {
                return DataRegistro.HasValue ? DataRegistro.Value.ToString("dd/MM/yyyy HH:mm") : "";
            }
        }

        [JsonIgnore]
        public Template Template { get; set; }
    }
}
