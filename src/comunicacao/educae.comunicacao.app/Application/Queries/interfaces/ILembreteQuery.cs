using educae.comunicacao.app.ViewModels;

namespace educae.comunicacao.app.Application.Queries.Interfaces;

public interface ILembreteQuery : IDisposable
{
    Task<IEnumerable<LembreteViewModel>> ObterLembretesPendentes();
    Task<IEnumerable<LembreteViewModel>> ObterLembretesFinalizados();
}
