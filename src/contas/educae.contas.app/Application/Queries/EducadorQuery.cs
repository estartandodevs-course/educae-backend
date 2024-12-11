using educae.contas.app.Application.Queries.Interfaces;
using educae.contas.app.ViewModels;
using educae.contas.domain.interfaces;

namespace educae.contas.app.Application.Queries;

public class EducadorQuery : IEducadorQuery
{
    private readonly IEducadorRepository _educadorRepository;

    public EducadorQuery(IEducadorRepository educadorRepository)
    {
        _educadorRepository = educadorRepository;
    }

    public async Task<IEnumerable<EducadorViewModel>> ObterEducadores()
    {
        var educadores = await _educadorRepository.ObterTodos();
        
        if(!educadores.Any()) return new List<EducadorViewModel>();

        return educadores.Select(EducadorViewModel.Mapear);
    }

    public async Task<EducadorViewModel> ObterEducadorPorId(Guid educadorId)
    {
        var educador = await _educadorRepository.ObterPorId(educadorId);
        
        if(educador is null) return new EducadorViewModel();
        
        return EducadorViewModel.Mapear(educador);
    }

    public async Task<EducadorViewModel> ObterEducadorPorCpf(string cpf)
    {
        var educador = await _educadorRepository.ObterPorCpf(cpf);
        
        if(educador is null) return new EducadorViewModel();
        
        return EducadorViewModel.Mapear(educador);    
    }
    
    public void Dispose()
    {
        _educadorRepository?.Dispose();
    }
}