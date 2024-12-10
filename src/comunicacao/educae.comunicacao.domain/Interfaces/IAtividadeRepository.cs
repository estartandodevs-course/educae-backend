using educae.comunicacao.domain.Entities;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.domain.Interfaces;

public interface IAtividadeRepository : IRepository<Atividade>
{
    Task<IEnumerable<Atividade>> ObterTodasAsAtividade();
    Task<IEnumerable<Atividade>> ObterTodasAsAtividadesFeitas();
    Task<IEnumerable<Atividade>> ObterTodasAsAtividadesPendentes();
    Task<IEnumerable<Atividade>> ObterAtividadesAtrasadas();
}