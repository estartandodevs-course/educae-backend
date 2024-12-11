using educae.contas.app.ViewModels;

namespace educae.contas.app.Application.Queries.Interfaces;

public interface IEducadorQuery : IDisposable
{
    Task<IEnumerable<EducadorViewModel>> ObterEducadores();
    Task<EducadorViewModel> ObterEducadorPorId(Guid educadorId);
    Task<EducadorViewModel> ObterEducadorPorCpf(string cpf);
}