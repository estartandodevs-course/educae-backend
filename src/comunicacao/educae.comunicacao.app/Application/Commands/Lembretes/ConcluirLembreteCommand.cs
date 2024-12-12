using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Lembretes
{
    public class ConcluirLembreteCommand : Command
    {
        public Guid Id { get; set; }

        public ConcluirLembreteCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            ValidationResult = new ConcluirLembreteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ConcluirLembreteValidation : AbstractValidator<ConcluirLembreteCommand>
        {
            public ConcluirLembreteValidation()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("O ID do lembrete é obrigatório.");
            }
        }
    }
}