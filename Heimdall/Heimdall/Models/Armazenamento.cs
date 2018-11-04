using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class Armazenamento
    {
        public string codUUID { get; set; }
        public string tipoArmazenamento { get; set; }
        public double capacidadeTotal { get; set; }
        public double capacidadeUtilizada { get; set; }
        public string letraLocal { get; set; }

    }
}