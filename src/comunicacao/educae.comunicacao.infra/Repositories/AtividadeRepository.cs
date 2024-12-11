using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.comunicacao.infra.Repositories;

public class AtividadeRepository : IAtividadeRepository
{
    private readonly ComunicacaoContext _context;

    public AtividadeRepository(ComunicacaoContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;

    public async Task<Atividade> ObterPorId(Guid Id)
    {
        return await _context.Atividades.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Adicionar(Atividade entity)
    {
        _context.Atividades.Add(entity);
    }

    public void Atualizar(Atividade entity)
    {
        _context.Atividades.Update(entity);
    }

    public void Apagar(Func<Atividade, bool> predicate)
    {
        var atividade = _context.Atividades.FirstOrDefault(predicate);
        _context.Atividades.Remove(atividade);
    }

    public async Task<IEnumerable<Atividade>> ObterTodasAsAtividade()
    {
        return await _context.Atividades.ToListAsync();
    }

    public async Task<IEnumerable<Atividade>> ObterTodasAsAtividadesFeitas()
    {
        return await _context.Atividades.Where(x => x.Feito == true)
            .OrderBy(x => x.DataDeAlteracao)
            .ToListAsync();
    }

    public async Task<IEnumerable<Atividade>> ObterTodasAsAtividadesPendentes()
    {
        return await _context.Atividades.Where(x => x.Feito == false)
                .OrderByDescending(x => x.DataMaximaEntrega)
                .ToListAsync();
    }

    public async Task<IEnumerable<Atividade>> ObterAtividadesAtrasadas()
    {
        return await _context.Atividades.Where(x => x.Feito == false && x.DataMaximaEntrega < DateTime.Now)
            .OrderByDescending(x => x.DataMaximaEntrega)
            .ToListAsync();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}