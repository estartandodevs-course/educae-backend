using educae.contas.domain;
using EstartandoDevsCore.Data;

namespace educae.contas.domain.interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>, IDisposable
    {
        Task<Aluno> ObterPorMatricula(string matricula);
        Task<IEnumerable<Aluno>> ObterTodos();
    }
}