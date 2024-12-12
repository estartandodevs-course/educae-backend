using educae.comunicacao.app.ViewModels;

namespace educae.comunicacao.app.Application.Queries.Interfaces;

public interface IAtividadeQuery : IDisposable
{
    Task<IEnumerable<AtividadeViewModel>> ObterAtividades();
}
