using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Lembretes
{
    public class AdicionarLembreteCommand : Command
    {
        public string Descricao { get; set; }

        public AdicionarLembreteCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AdicionarLembreteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarLembreteValidation : AbstractValidator<AdicionarLembreteCommand>
        {
            public AdicionarLembreteValidation()
            {
                RuleFor(x => x.Descricao)
                    .NotEmpty().WithMessage("A descrição é obrigatória.")
                    .MaximumLength(250).WithMessage("A descrição deve ter no máximo 250 caracteres.");
            }
        }
    }
}