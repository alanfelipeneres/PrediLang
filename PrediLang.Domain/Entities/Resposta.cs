using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Entities
{
    [Table("Resposta")]
    public class Resposta
    {
        [Key]
        public int IdResposta { get; set; }
        public int IdTemplate { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTime DataRegistro { get; set; }

        public Template Template { get; set; }
    }
}
