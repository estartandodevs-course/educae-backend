using educae.biblioteca.app.Application.Queries.Interfaces;
using educae.biblioteca.app.ViewModels;
using educae.biblioteca.domain.Entities;
using educae.biblioteca.domain.Interfaces;

namespace educae.biblioteca.app.Application.Queries;

public class CartilhaQuery : ICartilhaQuery
{
    private readonly ICartilhaRepository _cartilhaRepository;

    public CartilhaQuery(ICartilhaRepository cartilhaRepository)
    {
        _cartilhaRepository = cartilhaRepository;
    }

    public async Task<IEnumerable<CartilhaViewModel>> ObterCartilhas()
    {
        var cartilhas = await _cartilhaRepository.ObterCartilhas();

        return cartilhas.Select(CartilhaViewModel.Mapear);
    }
}