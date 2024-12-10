using educae.comunicacao.domain.Entities;
using EstartandoDevsCore.Data;

namespace educae.comunicacao.domain.Interfaces;

public interface IComunicadoRepository : IRepository<Comunicado>
{
    Task<IEnumerable<Comunicado>> ListarComunicados();
    Task<IEnumerable<Comunicado>> ListarComunicadosAtivos();
    Task<IEnumerable<Comunicado>> ListarComunicadosExpirados();
}