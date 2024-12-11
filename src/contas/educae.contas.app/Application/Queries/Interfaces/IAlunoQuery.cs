using educae.contas.app.ViewModels;
using educae.contas.domain;

namespace educae.contas.app.Application.Queries.Interfaces;

public interface IAlunoQuery : IDisposable
{
    Task<IEnumerable<AlunoViewModel>> ObterAlunos();
    Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId);
    Task<AlunoViewModel> ObterAlunoPorMatricula(string matricula);

}