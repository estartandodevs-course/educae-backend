"using educae.contas.domain;
using EstartandoDevsCore.Data;

namespace educae.contas.domain.interfaces
{
    public interface IEducadorRepository : IRepository<Educador>, IDisposable
    {
        Task<Educador> ObterPorCpf(string cpf);
        Task<IEnumerable<Educador>> ObterTodos();
    }
}