using educae.comunicacao.app.Application.Commands.Atividades;
using educae.comunicacao.app.Application.Queries.Interfaces;
using EstartandoDevsCore.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
public class AtividadesController : Controller
{
    private readonly IMediatorHandler _mediatorHandler;

    private readonly IAtividadeQuery _atividadeQuery;

    public AtividadesController(IMediatorHandler mediatorHandler, IAtividadeQuery atividadeQuery)
    {
        _mediatorHandler = mediatorHandler;
        _atividadeQuery = atividadeQuery;
    }

    [HttpGet]
    public async Task<IActionResult> ObterAtividades()
    {
        var atividades = await _atividadeQuery.ObterAtividades();
        return atividades.Any() ? Ok(atividades) : NoContent();
    }

    [HttpGet("feitas")]
    public async Task<IActionResult> ObterAtividadesFeitas()
    {
        var atividades = await _atividadeQuery.ObterAtividadesFeitas();
        return atividades.Any() ? Ok(atividades) : NoContent();
    }

    [HttpGet("pendentes")]
    public async Task<IActionResult> ObterAtividadesPendentes()
    {
        var atividades = await _atividadeQuery.ObterAtividadesPendentes();
        return atividades.Any() ? Ok(atividades) : NoContent();
    }

    [HttpGet("atrasadas")]
    public async Task<IActionResult> ObterAtividadesAtrasadas()
    {
        var atividades = await _atividadeQuery.ObterAtividadesAtrasadas();
        return atividades.Any() ? Ok(atividades) : NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAtividade([FromBody] AdicionarAtividadeCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _mediatorHandler.EnviarComando(command);

        if (resultado.IsValid)
            return Ok(new { success = true });

        return BadRequest(new
        {
            success = false,
            errors = resultado.Errors.Select(e => e.ErrorMessage)
        });
    }

    [HttpPost("{id:guid}/enviar")]
    public async Task<IActionResult> EnviarAtividade(Guid id, [FromBody] EnviarAtividadeCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != command.AtividadeId)
            return BadRequest("ID da atividade no corpo da requisição não corresponde ao ID na URL.");

        var resultado = await _mediatorHandler.EnviarComando(command);

        if (resultado.IsValid)
            return Ok(new { success = true });

        return BadRequest(new
        {
            success = false,
            errors = resultado.Errors.Select(e => e.ErrorMessage)
        });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditarAtividade(Guid id, [FromBody] EditarAtividadeCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != command.AtividadeId)
            return BadRequest("ID da atividade no corpo da requisição não corresponde ao ID na URL.");

        var resultado = await _mediatorHandler.EnviarComando(command);

        if (resultado.IsValid)
            return Ok(new { success = true });

        return BadRequest(new
        {
            success = false,
            errors = resultado.Errors.Select(e => e.ErrorMessage)
        });
    }
}