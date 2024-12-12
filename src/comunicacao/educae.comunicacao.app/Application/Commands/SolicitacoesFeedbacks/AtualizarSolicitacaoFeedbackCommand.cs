using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class AtualizarSolicitacaoFeedbackCommand : Command
    {
        public Guid SolicitacaoId { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public AtualizarSolicitacaoFeedbackCommand(Guid solicitacaoId, string assunto, string conteudo)
        {
            SolicitacaoId = solicitacaoId;
            Assunto = assunto;
            Conteudo = conteudo;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AtualizarSolicitacaoFeedbackValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarSolicitacaoFeedbackValidation : AbstractValidator<AtualizarSolicitacaoFeedbackCommand>
        {
            public AtualizarSolicitacaoFeedbackValidation()
            {
                RuleFor(x => x.SolicitacaoId)
                    .NotEmpty().WithMessage("O ID da solicitação é obrigatório.");

                RuleFor(x => x.Assunto)
                    .NotEmpty().WithMessage("O assunto é obrigatório.");

                RuleFor(x => x.Conteudo)
                    .NotEmpty().WithMessage("O conteúdo é obrigatório.");
            }
        }
    }
}