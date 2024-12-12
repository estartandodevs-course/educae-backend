using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.ViewModels;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application.Queries;

public class SolicitacaoFeedbackQuery : ISolicitacaoFeedbackQuery
{
    private readonly ISolicitacaoFeedBackRepository _repository;

    public SolicitacaoFeedbackQuery(ISolicitacaoFeedBackRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SolicitacaoFeedbackViewModel>> ObterSolicitacoesEmAberto()
    {
        var solicitacoes = await _repository.ObterSolicitacoesEmAberto();

        if (!solicitacoes.Any()) return new List<SolicitacaoFeedbackViewModel>();

        return solicitacoes.Select(SolicitacaoFeedbackViewModel.Mapear).ToList();
    }

    public async Task<IEnumerable<SolicitacaoFeedbackViewModel>> ObterSolicitacoesFechadas()
    {
        var solicitacoes = await _repository.ObterSolicitacoesFechadas();

        if (!solicitacoes.Any()) return new List<SolicitacaoFeedbackViewModel>();

        return solicitacoes.Select(SolicitacaoFeedbackViewModel.Mapear).ToList();
    }

    public void Dispose()
    {
        _repository?.Dispose();
    }
}

