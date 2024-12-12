using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.ViewModels;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application.Queries;

public class AtividadeQuery : IAtividadeQuery
{
  private readonly IAtividadeRepository _atividadeRepository;

  public AtividadeQuery(IAtividadeRepository atividadeRepository)
  {
    _atividadeRepository = atividadeRepository;
  }

  public async Task<IEnumerable<AtividadeViewModel>> ObterAtividades()
  {
    var atividades = await _atividadeRepository.ObterTodasAsAtividade();

    if (!atividades.Any()) return new List<AtividadeViewModel>();

    return atividades.Select(AtividadeViewModel.Mapear);
  }

  public async Task<IEnumerable<AtividadeViewModel>> ObterAtividadesFeitas()
  {
    var atividades = await _atividadeRepository.ObterTodasAsAtividadesFeitas();

    if (!atividades.Any()) return new List<AtividadeViewModel>();

    return atividades.Select(AtividadeViewModel.Mapear);
  }

  public async Task<IEnumerable<AtividadeViewModel>> ObterAtividadesPendentes()
  {
    var atividades = await _atividadeRepository.ObterTodasAsAtividadesPendentes();

    if (!atividades.Any()) return new List<AtividadeViewModel>();

    return atividades.Select(AtividadeViewModel.Mapear);
  }

  public async Task<IEnumerable<AtividadeViewModel>> ObterAtividadesAtrasadas()
  {
    var atividades = await _atividadeRepository.ObterAtividadesAtrasadas();

    if (!atividades.Any()) return new List<AtividadeViewModel>();

    return atividades.Select(AtividadeViewModel.Mapear);
  }

  public void Dispose()
  {
    _atividadeRepository?.Dispose();
  }
}
