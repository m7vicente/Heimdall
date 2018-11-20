using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class Usuario
    {
        public int codUsuario { get; set; }

        public string nomeCompleto { get; set; }

        public string email { get; set; }

        public string cargo { get; set; }

        public string senha { get; set; }

        public bool ativo { get; set; }

        public DateTime dataCadastro {get;set;}

        public Computador computador { get; set; }

        private List<Computador> Computadores { get; set; }
    }
}