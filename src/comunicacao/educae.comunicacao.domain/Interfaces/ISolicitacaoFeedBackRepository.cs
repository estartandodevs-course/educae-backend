using educae.comunicacao.domain.Entities;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.domain.Interfaces;

public interface ISolicitacaoFeedBackRepository : IRepository<SolicitacaoFeedback>
{
    Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesEmAberto();
    Task<IEnumerable<SolicitacaoFeedback>> ObterSolicitacoesFechadas();
}