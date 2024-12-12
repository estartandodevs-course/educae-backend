using educae.comunicacao.app.ViewModels;

namespace educae.comunicacao.app.Application.Queries.Interfaces;

public interface IComunicadoQuery : IDisposable
{
    Task<IEnumerable<ComunicadoViewModel>> ObterComunicados();
}
