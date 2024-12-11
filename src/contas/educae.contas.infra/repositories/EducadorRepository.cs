using educae.contas.domain;
using educae.contas.domain.interfaces;
using educae.contas.infra.data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.contas.infra.repositories
{
    public class EducadorRepository : IEducadorRepository
    {
        private readonly UsuarioContext _context;

        public EducadorRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Educador educador)
        {
            _context.Educadores.Add(educador);
        }

        public void Atualizar(Educador educador)
        {
            _context.Educadores.Update(educador);
        }

        public void Apagar(Func<Educador, bool> predicate)
        {
            var educadores = _context.Educadores.Where(predicate).ToList();
            _context.Educadores.RemoveRange(educadores);
        }

        public async Task<Educador> ObterPorId(Guid Id)
        {
            return await _context.Educadores.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Educador> ObterPorCpf(string cpf)
        {
            return await _context.Educadores.FirstOrDefaultAsync(x => x.CPF.Numero == cpf);
        }

        public async Task<IEnumerable<Educador>> ObterTodos()
        {
            return await _context.Educadores.OrderBy(x => x.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}