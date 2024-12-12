using educae.contas.app.Models;
using educae.contas.app.Application.Commands.Educadores;
using educae.contas.app.Application.Queries.Interfaces;
using educae.contas.domain.enums;
using EstartandoDevsCore.Mediator;
using EstartandoDevsCore.ValueObjects;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
public class EducadoresController : MainController
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IEducadorQuery _educadorQuery;

    public EducadoresController(IMediatorHandler mediatorHandler, IEducadorQuery educadorQuery)
    {
        _mediatorHandler = mediatorHandler;
        _educadorQuery = educadorQuery;
    }

    /// <summary>
    /// Recurso para cadastrar um educador
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] EducadorModel model)
    {
        if(!ModelState.IsValid) return CustomResponse(ModelState);
        
        var command = new CadastrarEducadorCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Cpf
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    /// <summary>
    /// Recurso para editar o perfil de um educador
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] EducadorModel model)
    {
        if(!ModelState.IsValid) return CustomResponse(ModelState);

        var command = new AtualizarEducadorCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Cpf
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    /// <summary>
    /// Recurso para obter educador pelo número do cpf
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    [HttpGet("{cpf}")]
    public async Task<IActionResult> ObterPorCpf(string cpf)
    {
        var educador = await _educadorQuery.ObterEducadorPorCpf(cpf);
        
        if (educador == null)
        {
            AdicionarErro("Aluno não encontrado");
            return CustomResponse();
        }
        
        return CustomResponse(educador);
    }

    /// <summary>
    /// Recurso para obter educador pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var educador = await _educadorQuery.ObterEducadorPorId(id);
        
        if (educador == null)
        {
            AdicionarErro("Aluno não encontrado");
            return CustomResponse();
        }
        
        return CustomResponse(educador);
    }

    /// <summary>
    /// Recurso para obter todos os educadores
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return CustomResponse(await _educadorQuery.ObterEducadores());
    }
}