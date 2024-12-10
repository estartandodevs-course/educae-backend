using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.contas.app.Application.Commands.Educador;

public class EducadorCommandHandler : CommandHandler,
    IRequestHandler<CadastrarEducadorCommand, ValidationResult>, IDisposable
{
    public Task<ValidationResult> Handle(CadastrarEducadorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}