using educae.biblioteca.domain.Entities;
using EstartandoDevsCore.Data;

namespace educae.biblioteca.domain.Interfaces;

public interface ICartilhaRepository : IRepository<Cartilha>
{
    Task<IEnumerable<Cartilha>> ObterCartilhas();
    Task<IEnumerable<Cartilha>> ObterCartilhasSalvas();
}