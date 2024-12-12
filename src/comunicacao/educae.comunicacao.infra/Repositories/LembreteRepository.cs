using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.comunicacao.infra.Repositories;

public class LembreteRepository : ILembreteRepository
{
  private readonly ComunicacaoContext _context;

  public LembreteRepository(ComunicacaoContext context)
  {
    _context = context;
  }

  public IUnitOfWorks UnitOfWork => _context;

  public async Task<Lembrete> ObterPorId(Guid Id)
  {
    return await _context.Lembretes.FirstOrDefaultAsync(x => x.Id == Id);
  }

  public void Adicionar(Lembrete entity)
  {
    _context.Lembretes.Add(entity);
  }

  public void Atualizar(Lembrete entity)
  {
    _context.Lembretes.Update(entity);
  }

  public void Apagar(Func<Lembrete, bool> predicate)
  {
    var lembrete = _context.Lembretes.FirstOrDefault(predicate);
    if (lembrete != null)
    {
      _context.Lembretes.Remove(lembrete);
    }
  }

  public async Task<IEnumerable<Lembrete>> ObterLembretesPendentes()
  {
    return await _context.Lembretes
        .Where(x => !x.Concluido)
        .ToListAsync();
  }

  public async Task<IEnumerable<Lembrete>> ObterLembretesFinalizados()
  {
    return await _context.Lembretes
        .Where(x => x.Concluido)
        .ToListAsync();
  }

  public void Dispose()
  {
    _context?.Dispose();
  }
}
