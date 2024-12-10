using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.contas.app.Application.Commands.Alunos;

public class AlunoCommandHandler : CommandHandler,
    IRequestHandler<CadastrarAlunoCommand, ValidationResult>, IDisposable
{
    public Task<ValidationResult> Handle(CadastrarAlunoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}