﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Entities
{
    public class Complemento
    {
        public int IdComplemento { get; set; }
        public int IdTemplate { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string Usuario { get; set; }
        public DateTime DataRegistro { get; set; }

        public Template Template { get; set; }
    }
}
