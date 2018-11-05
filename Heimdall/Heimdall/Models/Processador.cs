using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class Processador
    {
        public int codUsuario { get; set; }
        public int codComputador { get; set; }
        public int codProcessador { get; set; }
        public string nomeFabricante { get; set; }
        public string modelo { get; set; }
        public double frequenciaBase { get; set; }
        public int nucleos { get; set; }
        public string serial { get; set; }
        public long processosExecucao { get; set; }
        public double velocidade { get; set; }
        public int porcentagemUtilizacao { get; set; }
        public int threadsExecucao { get; set; }
        public string tempoExecucao { get; set; }
        public double temperaturaCpu { get; set; }
    }
}