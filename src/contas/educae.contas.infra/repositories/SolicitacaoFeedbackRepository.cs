using educae.comunicacao.domain;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.comunicacao.infra.Repositories;

public class SolicitacaoFeedbackRepository : ISolicitacaoFeedBackRepository
{
    private readonly ComunicacaoContext _context;

    public SolicitacaoFeedbackRepository(ComunicacaoContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;

    public async Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesEmAberto()
    {
        return await _context.SolicitacoesFeedback
            .Where(x => x.Aberta)
            .OrderBy(x => x.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesFechadas()
    {
        return await _context.SolicitacoesFeedback
            .Where(x => !x.Aberta)
            .OrderByDescending(x => x.DataCriacao)
            .ToListAsync();
    }

    public async Task<SolicitacaoFeedback> ObterPorId(Guid id)
    {
        return await _context.SolicitacoesFeedback
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Adicionar(SolicitacaoFeedback entity)
    {
        _context.SolicitacoesFeedback.Add(entity);
    }

    public void Atualizar(SolicitacaoFeedback entity)
    {
        _context.SolicitacoesFeedback.Update(entity);
    }

    public void Apagar(Func<SolicitacaoFeedback, bool> predicate)
    {
        var solicitacao = _context.SolicitacoesFeedback.FirstOrDefault(predicate);
        if (solicitacao != null)
        {
            _context.SolicitacoesFeedback.Remove(solicitacao);
        }
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
