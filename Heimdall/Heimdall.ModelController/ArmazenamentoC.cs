using System;
using System.Collections.Generic;
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

        internal List<Armazenamento> BuscarTodosArmazenamentos(int codComputador)
        {
            List<Armazenamento> lista = ADataAccess.buscar(codComputador);


            foreach(Armazenamento armazenamento in lista)
            {
                Armazenamento _temp = HDataAccess.buscar(armazenamento);
                armazenamento.capacidadeUtilizada = _temp.capacidadeUtilizada;
                armazenamento.dataEstado = _temp.dataEstado;
                armazenamento.letraLocal = _temp.letraLocal;
            }           

            return lista;


        }
    }
}