using Microsoft.AspNetCore.Mvc;
using MediatR;
using educae.comunicacao.app.Application.Commands.Lembretes;
using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.ViewModels;
using FluentValidation.Results;

namespace src.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LembretesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILembreteQuery _lembreteQuery;

    public LembretesController(IMediator mediator, ILembreteQuery lembreteQuery)
    {
        _mediator = mediator;
        _lembreteQuery = lembreteQuery;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> AdicionarLembrete([FromBody] AdicionarLembreteCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        ValidationResult result = await _mediator.Send(command);

        if (!result.IsValid) return BadRequest(result.Errors);

        return Ok("Lembrete adicionado com sucesso.");
    }

    [HttpPost("concluir/{id}")]
    public async Task<IActionResult> ConcluirLembrete(Guid id)
    {
        var command = new ConcluirLembreteCommand(id);

        ValidationResult result = await _mediator.Send(command);

        if (!result.IsValid) return BadRequest(result.Errors);

        return Ok("Lembrete concluído com sucesso.");
    }

    [HttpPost("desconcluir/{id}")]
    public async Task<IActionResult> DesconcluirLembrete(Guid id)
    {
        var command = new DesconcluirLembreteCommand(id);

        ValidationResult result = await _mediator.Send(command);

        if (!result.IsValid) return BadRequest(result.Errors);

        return Ok("Lembrete desconcluído com sucesso.");
    }

    [HttpGet("pendentes")]
    public async Task<IActionResult> ObterLembretesPendentes()
    {
        var lembretes = await _lembreteQuery.ObterLembretesPendentes();

        if (!lembretes.Any()) return NoContent();

        return Ok(lembretes);
    }

    [HttpGet("finalizados")]
    public async Task<IActionResult> ObterLembretesFinalizados()
    {
        var lembretes = await _lembreteQuery.ObterLembretesFinalizados();

        if (!lembretes.Any()) return NoContent();

        return Ok(lembretes);
    }
}
