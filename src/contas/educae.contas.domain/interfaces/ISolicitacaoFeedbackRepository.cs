using educae.comunicacao.domain;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.domain.Interfaces;

public interface ISolicitacaoFeedBackRepository : IRepository<SolicitacaoFeedback>
{
    Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesEmAberto();
    Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesFechadas();
}