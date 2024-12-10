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

        public Task<Educador> ObterPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Educador entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Educador entity)
        {
            throw new NotImplementedException();
        }

        public void Apagar(Func<Educador, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWorks UnitOfWork { get; }
        public Task<Educador> ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Educador>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}