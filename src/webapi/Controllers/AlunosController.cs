using educae.contas.app.Models;
using educae.contas.app.Application.Commands.Alunos;
using educae.contas.app.Application.Queries.Interfaces;
using educae.contas.domain.enums;
using EstartandoDevsCore.Mediator;
using EstartandoDevsCore.ValueObjects;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
public class AlunosController : MainController
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoQuery _alunoQuery;

    public AlunosController(IMediatorHandler mediatorHandler, IAlunoQuery alunoQuery)
    {
        _mediatorHandler = mediatorHandler;
        _alunoQuery = alunoQuery;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] AlunoModel model)
    {
        var command = new CadastrarAlunoCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Matricula
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] AlunoModel model)
    {
        var command = new AtualizarAlunoCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Matricula
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    [HttpGet("{matricula}")]
    public async Task<IActionResult> ObterPorMatricula(string matricula)
    {
        var aluno = await _alunoQuery.ObterAlunoPorMatricula(matricula);
        if (aluno == null) return NotFound();
        return CustomResponse(aluno);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return CustomResponse(await _alunoQuery.ObterAlunos());
    }
}