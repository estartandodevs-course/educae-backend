using educae.contas.domain;
using educae.contas.domain.enums;
using educae.contas.domain.interfaces;
using educae.contas.domain.ValueObject;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.contas.app.Application.Commands.Alunos;

public class AlunoCommandHandler : CommandHandler,
    IRequestHandler<CadastrarAlunoCommand, ValidationResult>, IDisposable
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<ValidationResult> Handle(CadastrarAlunoCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return request.ValidationResult;

        var alunoExistente = await _alunoRepository.ObterPorMatricula(request.Matricula);
        if (alunoExistente != null)
        {
            AdicionarErro("Já existe um aluno com essa matrícula.");
            return ValidationResult;
        }

        var aluno = new Aluno(
            nome: request.Nome,
            login: new Login(request.Email, request.Senha),
            tipoUsuario: TipoUsuario.Aluno,
            matricula: request.Matricula
        );

        _alunoRepository.Adicionar(aluno);

        return await PersistirDados(_alunoRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(AtualizarAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.ObterPorMatricula(request.Matricula);

        if (aluno == null)
        {
            AdicionarErro("Usuário não encontrado.");
            return ValidationResult;
        }

        aluno.AtribuirNome(request.Nome);
        aluno.AtribuirLogin(new Login(request.Email, request.Senha));
        aluno.AtribuirTipoUsuario(request.TipoUsuario);
        aluno.Matricula = request.Matricula;

        _alunoRepository.Atualizar(aluno);

        return await PersistirDados(_alunoRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _alunoRepository.Dispose();
    }
}