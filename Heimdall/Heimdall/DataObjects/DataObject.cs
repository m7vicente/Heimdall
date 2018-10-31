using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.DataObjects
{
    interface DataObject<TEntity> where TEntity : class
    {
        bool Inserir(TEntity obj);

        void Deletar(TEntity obj);

        void Update(TEntity obj);

        List<TEntity> Selecionar();

        TEntity buscar(TEntity obj);
    }
}
