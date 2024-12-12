using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Lembretes
{
    public class DesconcluirLembreteCommand : Command
    {
        public Guid Id { get; set; }

        public DesconcluirLembreteCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            ValidationResult = new DesconcluirLembreteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DesconcluirLembreteValidation : AbstractValidator<DesconcluirLembreteCommand>
        {
            public DesconcluirLembreteValidation()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("O ID do lembrete é obrigatório.");
            }
        }
    }
}