using educae.contas.domain;
using EstartandoDevsCore.Data;

namespace educae.contas.infra.interfaces
{
    public interface IEducadorRepository : IDisposable
    {
        Task<Educador> ObterPorCpf(string cpf);
        Task<IEnumerable<Educador>> ObterTodos();
        void Adicionar(Educador educador);
        void Atualizar(Educador educador);
        void Apagar(Func<Educador, bool> predicate);
        IUnitOfWorks UnitOfWork { get; }
    }
}