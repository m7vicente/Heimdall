using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class HistoricoEstadoRam
    {
        public double memoriaUtilizada { get; set; }
        public double memoriaDisponivel { get; set; }
        public double memoriaTotal { get; set; }
        public double swapUtilizada { get; set; }
        public double swapTotal { get; set; }
        public int porcentagemUtilizacao { get; set; }
    }
}