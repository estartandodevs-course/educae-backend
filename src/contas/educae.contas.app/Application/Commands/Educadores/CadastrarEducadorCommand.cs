using educae.contas.domain.enums;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using FluentValidation;

namespace educae.contas.app.Application.Commands.Educadores
{
    public class CadastrarEducadorCommand : Command
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public CadastrarEducadorCommand(string nome, Email email, Senha senha,
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
            ValidationResult = new CadastrarEducadorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CadastrarEducadorValidation : AbstractValidator<CadastrarEducadorCommand>
        {
            public CadastrarEducadorValidation()
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

                RuleFor(x => x.TipoUsuario)
                    .NotEmpty().WithMessage("Por favor informe o tipo do novo usuário!")
                    .NotNull().WithMessage("Por favor informe o tipo do novo usuário!");
            }
        }
    }
}