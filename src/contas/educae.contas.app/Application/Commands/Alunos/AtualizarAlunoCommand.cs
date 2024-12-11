using educae.contas.domain.enums;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using FluentValidation;

namespace educae.contas.app.Application.Commands.Alunos
{
    public class AtualizarAlunoCommand : Command
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }

        public AtualizarAlunoCommand(string nome, Email email, Senha senha,
            TipoUsuario tipoUsuario, string telefone, string matricula)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Telefone = telefone;
            Matricula = matricula;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AtualizarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarAlunoValidation : AbstractValidator<AtualizarAlunoCommand>
        {
            public AtualizarAlunoValidation()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                    .NotNull().WithMessage("O campo Nome é obrigatório.");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("O campo Email é obrigatório.")
                    .NotNull().WithMessage("O campo Email é obrigatório.");

                RuleFor(x => x.Matricula)
                    .NotEmpty().WithMessage("O campo Matrícula é obrigatório.")
                    .NotNull().WithMessage("O campo Matrícula é obrigatório.");
            }
        }
    }
}