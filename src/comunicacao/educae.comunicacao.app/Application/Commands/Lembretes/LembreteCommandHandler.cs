using EstartandoDevsCore.Messages;
using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace educae.comunicacao.app.Application.Commands.Lembretes
{
    public class LembreteCommandHandler : CommandHandler,
        IRequestHandler<AdicionarLembreteCommand, ValidationResult>,
        IRequestHandler<ConcluirLembreteCommand, ValidationResult>,
        IRequestHandler<DesconcluirLembreteCommand, ValidationResult>,
        IDisposable
    {
        private readonly ILembreteRepository _lembreteRepository;

        public LembreteCommandHandler(ILembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarLembreteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var lembrete = new Lembrete(request.Descricao, false);

            _lembreteRepository.Adicionar(lembrete);

            return await PersistirDados(_lembreteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ConcluirLembreteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var lembrete = await _lembreteRepository.ObterPorId(request.Id);

            if (lembrete == null)
            {
                AdicionarErro("Lembrete não encontrado.");
                return ValidationResult;
            }

            lembrete.ConcluirLembrete();
            _lembreteRepository.Atualizar(lembrete);

            return await PersistirDados(_lembreteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DesconcluirLembreteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var lembrete = await _lembreteRepository.ObterPorId(request.Id);

            if (lembrete == null)
            {
                AdicionarErro("Lembrete não encontrado.");
                return ValidationResult;
            }

            lembrete.DesconcluirLembrete();
            _lembreteRepository.Atualizar(lembrete);

            return await PersistirDados(_lembreteRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _lembreteRepository.Dispose();
        }
    }
}