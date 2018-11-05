using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.Models
{
    public class Computador
    {
        public int codUsuario { get; set; }
        public int codComputador { get; set; }
        public string nomeComputador { get; set; }
        public string fabricanteComputador { get; set; }
        public string modeloComputador { get; set; }
        public string ipv4Computador { get; set; }
        public string versaoFirmware { get; set; }
        public string nomePersonalizado { get; set; }

        public Processador processadores { get; set; }
        public List<Armazenamento> armazenamentos { get; set; }
        public SistemaOperacional OS { get; set; }
        public HistoricoEstadoRam RAM { get; set; }
    }
}