using educae.comunicacao.app.ViewModels;

namespace educae.comunicacao.app.Application.Queries.Interfaces;

public interface ISolicitacaoFeedbackQuery : IDisposable
{
    Task<IEnumerable<SolicitacaoFeedbackViewModel>> ObterSolicitacoesEmAberto();
    Task<IEnumerable<SolicitacaoFeedbackViewModel>> ObterSolicitacoesFechadas();
}
