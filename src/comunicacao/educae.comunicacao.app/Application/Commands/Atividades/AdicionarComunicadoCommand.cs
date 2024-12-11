using EstartandoDevsCore.Messages;
using FluentValidation;


namespace educae.comunicacao.app.Application.Commands.Comunicados
{
    public class AdicionarComunicadoCommand : Command
    {
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Guid UsuarioId { get; set; } 

        public AdicionarComunicadoCommand(string assunto, string conteudo, Guid usuarioId)
        {
            Assunto = assunto;
            Conteudo = conteudo;
            UsuarioId = usuarioId;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AdicionarComunicadoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarComunicadoValidation : AbstractValidator<AdicionarComunicadoCommand>
        {
            public AdicionarComunicadoValidation()
            {
                RuleFor(x => x.Assunto)
                    .NotEmpty().WithMessage("O campo Assunto é obrigatório.")
                    .NotNull().WithMessage("O campo Assunto não pode ser nulo.")
                    .MaximumLength(100).WithMessage("O campo Assunto pode ter no máximo 100 caracteres.");

                RuleFor(x => x.Conteudo)
                    .NotEmpty().WithMessage("O campo Conteúdo é obrigatório.")
                    .NotNull().WithMessage("O campo Conteúdo não pode ser nulo.")
                    .MaximumLength(1000).WithMessage("O campo Conteúdo pode ter no máximo 1000 caracteres.");

                RuleFor(x => x.UsuarioId)
                    .NotEmpty().WithMessage("O campo UsuarioId é obrigatório.")
                    .NotNull().WithMessage("O campo UsuarioId não pode ser nulo.");
            }
        }
    }
}