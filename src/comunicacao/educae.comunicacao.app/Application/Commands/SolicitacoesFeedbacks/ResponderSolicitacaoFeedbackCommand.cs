using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class ResponderSolicitacaoFeedbackCommand : Command
    {
        public Guid SolicitacaoId { get; set; }
        public string Resposta { get; set; }

        public ResponderSolicitacaoFeedbackCommand(Guid solicitacaoId, string resposta)
        {
            SolicitacaoId = solicitacaoId;
            Resposta = resposta;
        }

        public override bool EstaValido()
        {
            ValidationResult = new ResponderSolicitacaoFeedbackValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ResponderSolicitacaoFeedbackValidation : AbstractValidator<ResponderSolicitacaoFeedbackCommand>
        {
            public ResponderSolicitacaoFeedbackValidation()
            {
                RuleFor(x => x.SolicitacaoId)
                    .NotEmpty().WithMessage("O ID da solicitação é obrigatório.");

                RuleFor(x => x.Resposta)
                    .NotEmpty().WithMessage("A resposta não pode estar vazia.");
            }
        }
    }
}