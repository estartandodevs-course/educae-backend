using System;
using EstartandoDevsCore.Data;

namespace educae.contas.domain.interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>, IDisposable
    {
        Task<IEnumerable<Usuario>> ObterTodos();
    }
}