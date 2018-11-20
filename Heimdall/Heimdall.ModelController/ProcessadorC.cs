using System;
using Heimdall.DataObjects;
using Heimdall.Models;

namespace Heimdall.ModelController
{
    public class ProcessadorC
    {
        private ProcessadorDO dataAccess = new ProcessadorDO();
        private HistoricoEstadoProcessadorDO HdataAccess = new HistoricoEstadoProcessadorDO();

        internal void Cadastrar(Processador processador)
        {
            dataAccess.Inserir(processador);
            processador = dataAccess.buscar(processador);
            HdataAccess.Inserir(processador);
        }

        internal void Update(Processador processador)
        {
            dataAccess.Update(processador);
        }

        internal void InserirEstado(Processador processador)
        {
            processador = dataAccess.buscar(processador);
            HdataAccess.Inserir(processador);
        }

        internal Processador BuscarProcessador(int codComputador)
        {
            return HdataAccess.buscar(dataAccess.buscar(codComputador));
                         
        }

    }

}