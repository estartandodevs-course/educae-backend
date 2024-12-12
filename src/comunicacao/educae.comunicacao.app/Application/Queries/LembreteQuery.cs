using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.ViewModels;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application.Queries;

public class LembreteQuery : ILembreteQuery
{
    private readonly ILembreteRepository _lembreteRepository;

    public LembreteQuery(ILembreteRepository lembreteRepository)
    {
        _lembreteRepository = lembreteRepository;
    }

    public async Task<IEnumerable<LembreteViewModel>> ObterLembretesPendentes()
    {
        var lembretes = await _lembreteRepository.ObterLembretesPendentes();

        if (!lembretes.Any()) return new List<LembreteViewModel>();

        return lembretes.Select(LembreteViewModel.Mapear);
    }

    public async Task<IEnumerable<LembreteViewModel>> ObterLembretesFinalizados()
    {
        var lembretes = await _lembreteRepository.ObterLembretesFinalizados();

        if (!lembretes.Any()) return new List<LembreteViewModel>();

        return lembretes.Select(LembreteViewModel.Mapear);
    }

    public void Dispose()
    {
        _lembreteRepository?.Dispose();
    }
}
