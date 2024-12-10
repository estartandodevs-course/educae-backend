using educae.contas.domain;
using EstartandoDevsCore.Data;

namespace educae.contas.infra.interfaces
{
    public interface IAlunoRepository : IDisposable
    {
        Task<Aluno> ObterPorMatricula(string matricula);
        Task<IEnumerable<Aluno>> ObterTodos();
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Apagar(Func<Aluno, bool> predicate);
        IUnitOfWorks UnitOfWork { get; }
    }
}