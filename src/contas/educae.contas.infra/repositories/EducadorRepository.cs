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
            _context.Usuarios.Add(educador);
        }

        public void Atualizar(Educador educador)
        {
            _context.Usuarios.Update(educador);
        }

        public void Apagar(Func<Educador, bool> predicate)
        {
            var educadores = _context.Usuarios.OfType<Educador>().Where(predicate).ToList();
            _context.Usuarios.RemoveRange(educadores);
        }

        public async Task<Educador> ObterPorId(Guid Id)
        {
            return await _context.Usuarios.OfType<Educador>().FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Educador> ObterPorCpf(string cpf)
        {
            return await _context.Usuarios.OfType<Educador>().FirstOrDefaultAsync(x => x.CPF.Numero == cpf);
        }

        public async Task<IEnumerable<Educador>> ObterTodos()
        {
            return await _context.Usuarios.OfType<Educador>().OrderBy(x => x.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}