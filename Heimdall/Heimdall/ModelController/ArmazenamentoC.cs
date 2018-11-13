using System;
using Heimdall.DataObjects;
using Heimdall.Models;

namespace Heimdall.ModelController
{
    public class ArmazenamentoC
    {
        private ArmazenamentoDO ADataAccess = new ArmazenamentoDO();
        private HistoricoEstadoArmazenamentoDO HDataAccess = new HistoricoEstadoArmazenamentoDO();

        internal void Cadastrar(Armazenamento armazenamento)
        {
            ADataAccess.Inserir(armazenamento);
            HDataAccess.Inserir(armazenamento);
        }

        internal void Update(Armazenamento armazenamento)
        {
            ADataAccess.Update(armazenamento);
            HDataAccess.Inserir(armazenamento);
            
        }

        internal void InserirEstado(Armazenamento armazenamento)
        {
            HDataAccess.Inserir(armazenamento);
        }
    }
}