using educae.comunicacao.app.ViewModels;

namespace educae.comunicacao.app.Application.Queries.Interfaces;

public interface IAtividadeQuery : IDisposable
{
    Task<IEnumerable<AtividadeViewModel>> ObterAtividades();
    Task<IEnumerable<AtividadeViewModel>> ObterAtividadesFeitas();
    Task<IEnumerable<AtividadeViewModel>> ObterAtividadesPendentes();
    Task<IEnumerable<AtividadeViewModel>> ObterAtividadesAtrasadas();
}
