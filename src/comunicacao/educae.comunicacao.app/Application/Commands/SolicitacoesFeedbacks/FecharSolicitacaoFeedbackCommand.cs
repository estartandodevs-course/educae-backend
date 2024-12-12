using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class FecharSolicitacaoFeedbackCommand : Command
    {
        public Guid SolicitacaoId { get; set; }

        public FecharSolicitacaoFeedbackCommand(Guid solicitacaoId)
        {
            SolicitacaoId = solicitacaoId;
        }

        public override bool EstaValido()
        {
            ValidationResult = new FecharSolicitacaoFeedbackValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class FecharSolicitacaoFeedbackValidation : AbstractValidator<FecharSolicitacaoFeedbackCommand>
        {
            public FecharSolicitacaoFeedbackValidation()
            {
                RuleFor(x => x.SolicitacaoId)
                    .NotEmpty().WithMessage("O ID da solicitação é obrigatório.");
            }
        }
    }
}