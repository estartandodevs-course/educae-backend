using educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks;
using educae.comunicacao.app.Application.Queries.Interfaces;
using EstartandoDevsCore.Mediator;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
public class SolicitacoesFeedbackController : MainController
{
    private readonly IMediatorHandler _mediatorHandler;

    private readonly ISolicitacaoFeedbackQuery _solicitacaoFeedbackQuery;

    public SolicitacoesFeedbackController(IMediatorHandler mediatorHandler, ISolicitacaoFeedbackQuery solicitacaoFeedbackQuery)
    {
        _mediatorHandler = mediatorHandler;
        _solicitacaoFeedbackQuery = solicitacaoFeedbackQuery;
    }

    [HttpGet("em-aberto")]
    public async Task<IActionResult> ObterSolicitacaoEmAberto()
    {
        var solicitacoes = await _solicitacaoFeedbackQuery.ObterSolicitacoesEmAberto();

        if (!solicitacoes.Any()) return NotFound("Nenhuma solicitação de feedback encontrada.");

        return Ok(solicitacoes);
    }

    [HttpGet("fechadas")]
    public async Task<IActionResult> ObterSolicitacoesFechadas()
    {
        var solicitacoes = await _solicitacaoFeedbackQuery.ObterSolicitacoesFechadas();
        return CustomResponse(solicitacoes);
    }

    [HttpPost]
    public async Task<IActionResult> CriarSolicitacao([FromBody] CriarSolicitacaoFeedbackCommand command)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var resultado = await _mediatorHandler.EnviarComando(command);
        return CustomResponse(resultado);
    }

    [HttpPost("{id:guid}/responder")]
    public async Task<IActionResult> ResponderSolicitacao(Guid id, [FromBody] ResponderSolicitacaoFeedbackCommand command)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != command.SolicitacaoId) return BadRequest("O ID informado não corresponde ao ID da solicitação.");

        var resultado = await _mediatorHandler.EnviarComando(command);
        return CustomResponse(resultado);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarSolicitacao(Guid id, [FromBody] AtualizarSolicitacaoFeedbackCommand command)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        if (id != command.SolicitacaoId) return BadRequest("O ID informado não corresponde ao ID da solicitação.");

        var resultado = await _mediatorHandler.EnviarComando(command);
        return CustomResponse(resultado);
    }
}