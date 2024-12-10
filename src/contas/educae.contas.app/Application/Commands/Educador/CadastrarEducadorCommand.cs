using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using FluentValidation;

namespace educae.contas.app.Application.Commands.Educador;

public class CadastrarEducadorCommand : Command
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public Senha Senha { get; set; }
    public int TipoUsuario { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }

    public CadastrarEducadorCommand(string nome, Email email, Senha senha, 
        int tipoUsuario, String cpf , string telefone)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        TipoUsuario = tipoUsuario;
        Cpf = cpf; 
        Telefone = telefone;
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
                .NotEmpty().WithMessage("A prorpiedade Nome é obrigatória!")
                .NotNull().WithMessage("A prorpiedade Nome é obrigatória!");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("A prorpiedade Email é obrigatória!")
                .NotNull().WithMessage("A prorpiedade Email é obrigatória!");
            
            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A prorpiedade Senha é obrigatória!")
                .NotNull().WithMessage("A prorpiedade Senha é obrigatória!");
            
            RuleFor(x => x.TipoUsuario)
                .NotEmpty().WithMessage("Por favor informe o tipo do novo usuário!")
                .NotNull().WithMessage("Por favor informe o tipo do novo usuário!");
        }
    }
}