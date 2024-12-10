using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using FluentValidation;

namespace educae.contas.app.Application.Commands.Alunos;

public class CadastrarAlunoCommand : Command
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public Senha Senha { get; set; }
    public int TipoUsuario { get; set; }
    public string Telefone { get; set; }
    public string Matricula { get; set; }

    public CadastrarAlunoCommand(string nome, Email email, Senha senha, 
        int tipoUsuario, string telefone, string matricula)
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
        ValidationResult = new CadastrarAlunoValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class CadastrarAlunoValidation : AbstractValidator<CadastrarAlunoCommand>
    {
        public CadastrarAlunoValidation()
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