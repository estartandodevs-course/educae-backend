using educae.biblioteca.app.ViewModels;
using educae.biblioteca.domain.Entities;

namespace educae.biblioteca.app.Application.Queries.Interfaces;

public interface ICartilhaQuery
{
    Task<IEnumerable<CartilhaViewModel>> ObterCartilhas();
}