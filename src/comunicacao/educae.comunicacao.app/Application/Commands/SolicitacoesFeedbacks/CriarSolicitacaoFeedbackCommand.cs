using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class CriarSolicitacaoFeedbackCommand : Command
    {
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Guid EducadorDestinatarioId { get; set; }
        public Guid? AlunoRemetenteId { get; set; }
        public bool EnvioAnonimo { get; set; }

        public CriarSolicitacaoFeedbackCommand
(string assunto, string conteudo,
            Guid educadorDestinatarioId, Guid? alunoRemetenteId, bool envioAnonimo)
        {
            Assunto = assunto;
            Conteudo = conteudo;
            EducadorDestinatarioId = educadorDestinatarioId;
            AlunoRemetenteId = alunoRemetenteId;
            EnvioAnonimo = envioAnonimo;
        }

        public class CriarSolicitacaoFeedbackValitadion : AbstractValidator<CriarSolicitacaoFeedbackCommand
>
        {
            public CriarSolicitacaoFeedbackValitadion()
            {
                RuleFor(x => x.Assunto)
                    .NotEmpty().WithMessage("O assunto é obrigatório.");

                RuleFor(x => x.Conteudo)
                    .NotEmpty().WithMessage("O conteúdo é obrigatório.");

                RuleFor(x => x.EducadorDestinatarioId)
                    .NotEmpty().WithMessage("O destinatário é obrigatório.");
            }
        }
    }
}