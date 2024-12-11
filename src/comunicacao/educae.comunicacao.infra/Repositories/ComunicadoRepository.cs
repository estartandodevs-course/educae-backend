using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace educae.comunicacao.infra.Repositories;

public class ComunicadoRepository : IComunicadoRepository
{
    private readonly ComunicacaoContext _context;

    public ComunicadoRepository(ComunicacaoContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;

    
    public async Task<Comunicado> ObterPorId(Guid Id)
    {
        return await _context.Comunicados.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Adicionar(Comunicado entity)
    {
        _context.Comunicados.Add(entity);
    }

    public void Atualizar(Comunicado entity)
    {
        _context.Comunicados.Update(entity);
    }

    public void Apagar(Func<Comunicado, bool> predicate)
    {
        var comunicado = _context.Comunicados.FirstOrDefault(predicate);
        _context.Comunicados.Remove(comunicado);
    }

    public async Task<IEnumerable<Comunicado>> ListarComunicados()
    {
        return await _context.Comunicados
            .OrderByDescending(x => x.DataExpiracao)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comunicado>> ListarComunicadosAtivos()
    {
        return await _context.Comunicados.Where(x => x.DataExpiracao > DateTime.Now)
            .OrderByDescending(x => x.DataExpiracao)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comunicado>> ListarComunicadosExpirados()
    {
        return await _context.Comunicados.Where(x => x.DataExpiracao < DateTime.Now)
            .OrderByDescending(x => x.DataExpiracao)
            .ToListAsync();    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}