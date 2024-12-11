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

        public IUnitOfWorks UnitOfWork => _context;


        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public void Apagar(Func<Aluno, bool> predicate)
        {
            var alunos = _context.Alunos.Where(predicate).ToList();
            _context.Alunos.RemoveRange(alunos);
        }
        public async Task<Aluno> ObterPorId(Guid Id)
        {
            return await _context.Alunos.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Aluno> ObterPorMatricula(string matricula)
        {
            return await _context.Alunos.FirstOrDefaultAsync(x => x.Matricula == matricula);
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _context.Alunos.OrderBy(x => x.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}