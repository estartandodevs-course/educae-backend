using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class AnonimoSolicitacaoFeedbackCommand : Command
    {
        public Guid SolicitacaoId { get; set; }
        public bool EnvioAnonimo { get; set; }

        public AnonimoSolicitacaoFeedbackCommand(Guid solicitacaoId, bool envioAnonimo)
        {
            SolicitacaoId = solicitacaoId;
            EnvioAnonimo = envioAnonimo;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AnonimoSolicitacaoFeedbackValitadion().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AnonimoSolicitacaoFeedbackValitadion : AbstractValidator<AnonimoSolicitacaoFeedbackCommand>
        {
            public AnonimoSolicitacaoFeedbackValitadion()
            {
                RuleFor(x => x.SolicitacaoId)
                    .NotEmpty().WithMessage("O ID da solicitação é obrigatório.");
            }
        }
    }
}