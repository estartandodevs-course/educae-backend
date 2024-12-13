using educae.biblioteca.app.Application.Queries.Interfaces;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartilhaController : MainController
{
    private readonly ICartilhaQuery _cartilhaQuery;

    public CartilhaController(ICartilhaQuery cartilhaQuery)
    {
        _cartilhaQuery = cartilhaQuery;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return CustomResponse(await _cartilhaQuery.ObterCartilhas());
    }
}