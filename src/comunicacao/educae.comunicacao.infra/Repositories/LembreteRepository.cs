using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.infra.Repositories;

public class LembreteRepository : ILembreteRepository
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<Lembrete> ObterPorId(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void Adicionar(Lembrete entity)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Lembrete entity)
    {
        throw new NotImplementedException();
    }

    public void Apagar(Func<Lembrete, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IUnitOfWorks UnitOfWork { get; }
    public Task<IEnumerable<Lembrete>> ObterLembretesPendentes()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Lembrete>> ObterLembretesFinalizados()
    {
        throw new NotImplementedException();
    }
}