using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educae.core.data
{
    public interface IRepository
    {
        IUnitOfWorks UnitOfWork { get; }

        Task<TEntity> ObterPorId(Guid id);

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Apagar(Func<TEntity, bool> predicate);
    }
}