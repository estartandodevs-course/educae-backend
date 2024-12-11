using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Comunicados;

public class EditarComunicadoCommand : Command
{
    public Guid AtividadeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }
    public DateTime DataExpiracao { get; set; }

    public EditarComunicadoCommand(Guid atividadeId, string titulo, string descricao, string imagem, DateTime dataExpiracao)
    {
        AtividadeId = atividadeId;
        Titulo = titulo;
        Descricao = descricao;
        Imagem = imagem;
        DataExpiracao = dataExpiracao;
    }

    public override bool EstaValido()
    {
        ValidationResult = new EditarComunicadoValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class EditarComunicadoValidation : AbstractValidator<EditarComunicadoCommand>
    {
        public EditarComunicadoValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O campo Titulo é obrigatório.")
                .NotNull().WithMessage("O campo Titulo não pode ser nulo.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório.")
                .NotNull().WithMessage("O campo Descricao não pode ser nulo.");

            RuleFor(x => x.Imagem)
                .NotEmpty().WithMessage("A propriedade imagem é obrigatória")
                .NotNull().WithMessage("A propriedade imagem é obrigatória");
                
            RuleFor(x => x.DataExpiracao)
                .NotEmpty().WithMessage("A propriedade Data de Expiração é obrigatória")
                .NotNull().WithMessage("A propriedade Data de Expiração é obrigatória")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A Data de expiração não pode ser no passado");
        }
    }
}