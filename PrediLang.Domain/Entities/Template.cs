using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Entities
{
    [Table("Template")]
    public class Template
    {
        [Key]
        public int IdTemplate { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTime DataRegistro { get; set; }

        public ICollection<Resposta> Respostas { get; set; }
        public ICollection<Complemento> Complementos { get; set; }
    }
}
