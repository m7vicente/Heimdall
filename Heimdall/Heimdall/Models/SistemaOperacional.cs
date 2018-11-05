using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class SistemaOperacional
    {
        public int codUsuario { get; set; }
        public int codComputador { get; set; }
        public int codSO { get; set; }
        public string fabricanteSO { get; set; }
        public string versaoSO { get; set; }
        public string familiaSO { get; set; }
    }
}