using System;
using Heimdall.DataObjects;
using Heimdall.Models;

namespace Heimdall.ModelController
{
    public class SistemaOperacionalC
    {
        SistemaOperacionalDO DataAccess = new SistemaOperacionalDO();
        internal void Cadastrar(SistemaOperacional OS)
        {
            DataAccess.Inserir(OS);
        }

        internal void Update(SistemaOperacional OS)
        {
            DataAccess.Update(OS);
        }
    }
}