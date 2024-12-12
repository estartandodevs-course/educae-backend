using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra.Data;
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

    public async Task<SolicitacaoFeedback> ObterPorId(Guid id)
    {
        return await _context.Solicitacoes
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Adicionar(SolicitacaoFeedback entity)
    {
        _context.Solicitacoes.Add(entity);
    }

    public void Atualizar(SolicitacaoFeedback entity)
    {
        _context.Solicitacoes.Update(entity);
    }

    public void Apagar(Func<SolicitacaoFeedback, bool> predicate)
    {
        var solicitacao = _context.Solicitacoes.FirstOrDefault(predicate);
        if (solicitacao != null)
        {
            _context.Solicitacoes.Remove(solicitacao);
        }
    }

    public async Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesEmAberto()
    {
        return await _context.Solicitacoes
            .Where(x => x.Aberta)
            .OrderBy(x => x.DataDeCadastro)
            .ToListAsync();
    }

    public async Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesFechadas()
    {
        return await _context.Solicitacoes
            .Where(x => !x.Aberta)
            .OrderByDescending(x => x.DataDeCadastro)
            .ToListAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
