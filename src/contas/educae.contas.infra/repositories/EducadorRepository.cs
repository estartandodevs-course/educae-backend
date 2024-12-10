using educae.contas.domain;
using educae.contas.infra.data;
using educae.contas.infra.interfaces;
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

        IUnitOfWorks IEducadorRepository.UnitOfWork => throw new NotImplementedException();

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

        public async Task<Educador> ObterPorCpf(string cpf)
        {
            return await _context.Usuarios.OfType<Educador>().FirstOrDefaultAsync(e => e.CPF.Numero == cpf);
        }

        public async Task<IEnumerable<Educador>> ObterTodos()
        {
            return await _context.Usuarios.OfType<Educador>().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}