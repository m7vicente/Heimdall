using System;
using Heimdall.DataObjects;
using Heimdall.Models;

namespace Heimdall.ModelController
{
    public class HistoricoEstadoRAMC
    {
        HistoricoRAMDO dataAccess = new HistoricoRAMDO();
        internal void Cadastrar(HistoricoEstadoRam RAM)
        {
            dataAccess.Inserir(RAM);
        }

        internal void Update(HistoricoEstadoRam RAM)
        {
            dataAccess.Inserir(RAM);
        }

        internal HistoricoEstadoRam BuscarRAM(int codComputador)
        {
            return dataAccess.buscar(codComputador);
        }
    }
}