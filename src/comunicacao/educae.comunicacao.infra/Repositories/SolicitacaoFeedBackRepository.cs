using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.infra.Repositories;

public class SolicitacaoFeedBackRepository : ISolicitacaoFeedBackRepository
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<SolicitacaoFeedback> ObterPorId(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void Adicionar(SolicitacaoFeedback entity)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(SolicitacaoFeedback entity)
    {
        throw new NotImplementedException();
    }

    public void Apagar(Func<SolicitacaoFeedback, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IUnitOfWorks UnitOfWork { get; }
    public Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesEmAberto()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesFechadas()
    {
        throw new NotImplementedException();
    }
}