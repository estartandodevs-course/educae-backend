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

    /// <summary>
    /// Recurso para cadastrar um aluno
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] AlunoModel model)
    {
        if(!ModelState.IsValid) return CustomResponse(ModelState);

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

    /// <summary>
    /// Recurso para editar o perfil de um aluno
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] AlunoModel model)
    {
        if(!ModelState.IsValid) return CustomResponse(ModelState);
        
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

    /// <summary>
    /// Recurso para obter aluno pelo número da matricula
    /// </summary>
    /// <param name="matricula"></param>
    /// <returns></returns>
    [HttpGet("{matricula}")]
    public async Task<IActionResult> ObterPorMatricula(string matricula)
    {
        var aluno = await _alunoQuery.ObterAlunoPorMatricula(matricula);
        
        if (aluno == null)
        {
            AdicionarErro("Aluno não encontrado");
            return CustomResponse();
        }
        
        return CustomResponse(aluno);
    }

    /// <summary>
    /// Recurso para obter aluno pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var aluno = await _alunoQuery.ObterAlunoPorId(id);
        
        if (aluno == null)
        {
            AdicionarErro("Aluno não encontrado");
            return CustomResponse();
        }
        
        return CustomResponse(aluno);
    }

    /// <summary>
    /// Recurso para obter todos os alunos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return CustomResponse(await _alunoQuery.ObterAlunos());
    }
}