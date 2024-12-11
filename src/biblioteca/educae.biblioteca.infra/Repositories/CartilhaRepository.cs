using educae.biblioteca.domain.Entities;
using educae.biblioteca.domain.Interfaces;
using educae.biblioteca.infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.biblioteca.infra.Repositories;

public class CartilhaRepository : ICartilhaRepository
{
    private readonly BibliotecaContext _context;
    
    public CartilhaRepository(BibliotecaContext context)
    {
        _context = context;
    }
    
    public IUnitOfWorks UnitOfWork => _context;

    public async Task<Cartilha> ObterPorId(Guid Id)
    {
        return await _context.Cartilhas.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Adicionar(Cartilha entity)
    {
        _context.Cartilhas.Add(entity);
    }

    public void Atualizar(Cartilha entity)
    {
        _context.Cartilhas.Update(entity);
    }

    public void Apagar(Func<Cartilha, bool> predicate)
    {
        var cartilha = _context.Cartilhas
            .Include(x => x.Anexos)
            .FirstOrDefault(predicate);
        
        _context.Cartilhas.Remove(cartilha);
    }

    public async Task<IEnumerable<Cartilha>> ObterCartilhas()
    {
        return await _context.Cartilhas
            .Include(x => x.Anexos)
            .OrderByDescending(x => x.DataDeCadastro)
            .ToListAsync();
    }

    public Task<IEnumerable<Cartilha>> ObterCartilhasSalvas()
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}