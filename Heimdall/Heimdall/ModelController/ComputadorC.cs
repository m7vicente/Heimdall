using Heimdall.DataObjects;
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.ModelController
{
    public class ComputadorC
    {
        private ComputadorDO dataAccess = new ComputadorDO();

        internal bool VerificarCadastro(Computador computador)
        {
            computador = dataAccess.buscar(computador);

            if (!(computador.codComputador == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void Cadastrar(Computador computador)
        {
            dataAccess.Inserir(computador);
            computador = dataAccess.buscar(computador);
        }

        internal List<Computador> MontarVisualizacao(int codUsuairo)
        {
            return dataAccess.Selecionar(codUsuairo);
        }
    }
}