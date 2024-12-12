using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class CriarSolicitacaoFeedbackCommand : Command
    {
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Guid UsuarioDestinatarioId { get; set; }
        public string NomeUsuarioDestinatario { get; set; }
        public string EmailUsuarioDestinatario { get; set; }
        public string FotoUsuarioDestinatario { get; set; }   
        public Guid AlunoRemetenteId { get; set; }
        public string? NomeAlunoRemetente { get; set; }
        public string? EmailAlunoRemetente { get; set; }
        public string? FotoAlunoRemetente { get; set; }        
        public bool EnvioAnonimo { get; set; }

        public CriarSolicitacaoFeedbackCommand(string assunto, string conteudo, Guid usuarioDestinatarioId, string nomeUsuarioDestinatario, 
            string emailUsuarioDestinatario, string fotoUsuarioDestinatario, Guid alunoRemetenteId, string? nomeAlunoRemetente, 
            string? emailAlunoRemetente, string? fotoAlunoRemetente, bool envioAnonimo)
        {
            Assunto = assunto;
            Conteudo = conteudo;
            UsuarioDestinatarioId = usuarioDestinatarioId;
            NomeUsuarioDestinatario = nomeUsuarioDestinatario;
            EmailUsuarioDestinatario = emailUsuarioDestinatario;
            FotoUsuarioDestinatario = fotoUsuarioDestinatario;
            AlunoRemetenteId = alunoRemetenteId;
            NomeAlunoRemetente = nomeAlunoRemetente;
            EmailAlunoRemetente = emailAlunoRemetente;
            FotoAlunoRemetente = fotoAlunoRemetente;
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

                RuleFor(x => x.UsuarioDestinatarioId)
                    .NotEmpty().WithMessage("O destinatário é obrigatório.");
            }
        }
    }
}