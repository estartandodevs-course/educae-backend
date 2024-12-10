using educae.contas.domain;
using educae.contas.domain.interfaces;
using educae.contas.infra.data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.contas.infra.repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly UsuarioContext _context;

        public AlunoRepository(UsuarioContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> ObterPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public void Apagar(Func<Aluno, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWorks UnitOfWork { get; }
        public Task<Aluno> ObterPorMatricula(string matricula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}