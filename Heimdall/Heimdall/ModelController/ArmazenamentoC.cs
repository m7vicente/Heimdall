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
    }
}