using educae.contas.app.Application.Queries.Interfaces;
using educae.contas.app.ViewModels;
using educae.contas.domain.interfaces;

namespace educae.contas.app.Application.Queries;

public class AlunoQuery : IAlunoQuery
{
    private readonly IAlunoRepository _repository;

    public AlunoQuery(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AlunoViewModel>> ObterAlunos()
    {
        var alunos = await _repository.ObterTodos();

        if (!alunos.Any()) return new List<AlunoViewModel>();

        return alunos.Select(AlunoViewModel.Mapear);
    }

    public async Task<AlunoViewModel> ObterAlunoPorId(Guid alunoId)
    {
        var aluno = await _repository.ObterPorId(alunoId);

        if (aluno is null) return new AlunoViewModel();
        
        return AlunoViewModel.Mapear(aluno);
    }

    public async Task<AlunoViewModel> ObterAlunoPorMatricula(string matricula)
    {
        var aluno = await _repository.ObterPorMatricula(matricula);

        if (aluno is null) return new AlunoViewModel();
        
        return AlunoViewModel.Mapear(aluno);    
    }

    public void Dispose()
    {
        _repository?.Dispose();
    }
}