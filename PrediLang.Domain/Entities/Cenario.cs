using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Entities
{
    [Table("Cenario")]
    public class Cenario
    {
        [Key]
        public int IdCenario { get; set; }
        public int IdTemplate { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string Usuario { get; set; }
        public DateTime DataRegistro { get; set; }

        [ForeignKey("IdTemplate")]
        public Template Template { get; set; }
    }
}
