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
            _context.Usuarios.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Usuarios.Update(aluno);
        }

        public void Apagar(Func<Aluno, bool> predicate)
        {
            var alunos = _context.Usuarios.OfType<Aluno>().Where(predicate).ToList();
            _context.Usuarios.RemoveRange(alunos);
        }
        public async Task<Aluno> ObterPorId(Guid Id)
        {
            //Utilização do OfType<Aluno>() devido o erro de conversão de tipo
            return await _context.Usuarios.OfType<Aluno>().FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Aluno> ObterPorMatricula(string matricula)
        {
            return await _context.Usuarios.OfType<Aluno>().FirstOrDefaultAsync(x => x.Matricula == matricula);
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _context.Usuarios.OfType<Aluno>().OrderBy(x => x.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}