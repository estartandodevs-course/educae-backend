using educae.comunicacao.domain.Entities;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.domain.Interfaces;

public interface ILembreteRepository : IRepository<Lembrete>
{
    Task<IEnumerable<Lembrete>> ObterLembretesPendentes();
    Task<IEnumerable<Lembrete>> ObterLembretesFinalizados();
}