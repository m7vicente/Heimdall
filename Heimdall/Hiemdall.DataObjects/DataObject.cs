using System.Collections.Generic;

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
