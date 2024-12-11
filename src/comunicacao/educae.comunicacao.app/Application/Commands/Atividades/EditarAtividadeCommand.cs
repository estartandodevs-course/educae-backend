using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Atividades;

public class EditarAtividadeCommand : Command
{
    public Guid AtividadeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataMaximaEntrega { get; set; }
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }

    public EditarAtividadeCommand(Guid atividadeId, string titulo, string descricao, DateTime dataMaximaEntrega, int avaliacaoDaExecucao, bool feito)
    {
        AtividadeId = atividadeId;
        Titulo = titulo;
        Descricao = descricao;
        DataMaximaEntrega = dataMaximaEntrega;
        AvaliacaoDaExecucao = avaliacaoDaExecucao;
        Feito = feito;
    }

    public override bool EstaValido()
    {
        ValidationResult = new EditarAtividadeValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class EditarAtividadeValidation : AbstractValidator<EditarAtividadeCommand>
    {
        public EditarAtividadeValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("A propriedade título é obrigatória")
                .NotNull().WithMessage("A propriedade título é obrigatória");
            
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A propriedade descrição é obrigatória")
                .NotNull().WithMessage("A propriedade descrição é obrigatória");
            
            RuleFor(x => x.DataMaximaEntrega)
                .NotEmpty().WithMessage("A propriedade DataMaximaEntrega é obrigatória")
                .NotNull().WithMessage("A propriedade DataMaximaEntrega é obrigatória")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A Data Maxima Entrega não pode ser no passado");
        }
    }
}