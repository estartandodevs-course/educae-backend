using educae.contas.domain.enums;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using FluentValidation;

namespace educae.contas.app.Application.Commands.Educadores
{
    public class AtualizarEducadorCommand : Command
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public AtualizarEducadorCommand(string nome, Email email, Senha senha,
            TipoUsuario tipoUsuario, string telefone, string cpf)
        {

            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Telefone = telefone;
            Cpf = cpf;
        }

        public override bool EstaValido()
        {
            ValidationResult = new AtualizarEducadorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarEducadorValidation : AbstractValidator<AtualizarEducadorCommand>
        {
            public AtualizarEducadorValidation()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("A propriedade Nome é obrigatória!")
                    .NotNull().WithMessage("A propriedade Nome é obrigatória!");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("A propriedade Email é obrigatória!")
                    .NotNull().WithMessage("A propriedade Email é obrigatória!");

                RuleFor(x => x.Senha)
                    .NotEmpty().WithMessage("A propriedade Senha é obrigatória!")
                    .NotNull().WithMessage("A propriedade Senha é obrigatória!");

                RuleFor(x => x.Cpf)
                    .NotEmpty().WithMessage("A propriedade CPF é obrigatória!")
                    .NotNull().WithMessage("A propriedade CPF é obrigatória!");
            }
        }
    }
}