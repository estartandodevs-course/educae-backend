using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.ViewModels;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application.Queries;

public class ComunicadoQuery : IComunicadoQuery
{
  private readonly IComunicadoRepository _comunicadoRepository;

  public ComunicadoQuery(IComunicadoRepository comunicadoRepository)
  {
    _comunicadoRepository = comunicadoRepository;
  }

  public async Task<IEnumerable<ComunicadoViewModel>> ObterComunicados()
  {
    var comunicados = await _comunicadoRepository.ListarComunicados();

    if (!comunicados.Any()) return new List<ComunicadoViewModel>();

    return comunicados.Select(ComunicadoViewModel.Mapear);
  }

  public async Task<IEnumerable<ComunicadoViewModel>> ObterComunicadosAtivos()
  {
    var comunicados = await _comunicadoRepository.ListarComunicadosAtivos();

    if (!comunicados.Any()) return new List<ComunicadoViewModel>();

    return comunicados.Select(ComunicadoViewModel.Mapear);
  }

  public async Task<IEnumerable<ComunicadoViewModel>> ObterComunicadosExpirados()
  {
    var comunicados = await _comunicadoRepository.ListarComunicadosExpirados();

    if (!comunicados.Any()) return new List<ComunicadoViewModel>();

    return comunicados.Select(ComunicadoViewModel.Mapear);
  }

  public void Dispose()
  {
    _comunicadoRepository?.Dispose();
  }
}
