using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.comunicacao.app.Application.Commands.Atividades;

public class AtividadeCommandHandler : CommandHandler,
    IRequestHandler<AdicionarAtividadeCommand, ValidationResult>, IDisposable
{
    public Task<ValidationResult> Handle(AdicionarAtividadeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}