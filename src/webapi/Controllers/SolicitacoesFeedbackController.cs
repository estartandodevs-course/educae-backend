using educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks;
using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.Models;
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

        if (!solicitacoes.Any())
        {
            AdicionarErro("Nenhuma solicitação de feedback encontrada.");
            return CustomResponse();
        }

        return CustomResponse(solicitacoes);
    }

    [HttpGet("fechadas")]
    public async Task<IActionResult> ObterSolicitacoesFechadas()
    {
        var solicitacoes = await _solicitacaoFeedbackQuery.ObterSolicitacoesFechadas();
        
        if (!solicitacoes.Any())
        {
            AdicionarErro("Nenhuma solicitação de feedback encontrada.");
            return CustomResponse();
        }
        
        return CustomResponse(solicitacoes);
    }

    [HttpPost]
    public async Task<IActionResult> CriarSolicitacao([FromBody] SolicitacaoFeedBackModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var comando = new CriarSolicitacaoFeedbackCommand(model.Assunto, model.Conteudo, model.EducadorDestinatario.Id,
            model.EducadorDestinatario.Nome, model.EducadorDestinatario.Email, model.EducadorDestinatario.Foto, 
            model.AlunoRementente.Id, model.AlunoRementente.Nome, model.AlunoRementente.Email, model.AlunoRementente.Foto,
            model.EnvioAnonimo);
        
        var resultado = await _mediatorHandler.EnviarComando(comando);
        return CustomResponse(resultado);
    }

    [HttpPost("responder")]
    public async Task<IActionResult> ResponderSolicitacao(Guid solicitacaoId, string resposta)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        
        var comando = new ResponderSolicitacaoFeedbackCommand(solicitacaoId, resposta);
        
        var resultado = await _mediatorHandler.EnviarComando(comando);
        return CustomResponse(resultado);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarSolicitacao([FromBody] AtualizarSolicitacaoFeedBackModel model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var comando = new AtualizarSolicitacaoFeedbackCommand(model.SolicitacaoId, model.Assunto, model.Conteudo);
        
        var resultado = await _mediatorHandler.EnviarComando(comando);
        return CustomResponse(resultado);
    }
}