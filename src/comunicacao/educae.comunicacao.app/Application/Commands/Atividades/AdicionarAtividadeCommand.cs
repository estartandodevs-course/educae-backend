using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Atividades;

public class AdicionarAtividadeCommand : Command
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataMaximaEntrega { get; set; }
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }

    public AdicionarAtividadeCommand(string titulo, string descricao, DateTime dataMaximaEntrega,
        int avaliacaoDaExecucao, bool feito)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataMaximaEntrega = dataMaximaEntrega;
        AvaliacaoDaExecucao = avaliacaoDaExecucao;
        Feito = feito;
    }

    public override bool EstaValido()
    {
        ValidationResult = new AdicionarAtividadeValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class AdicionarAtividadeValidation : AbstractValidator<AdicionarAtividadeCommand>
    {
        public AdicionarAtividadeValidation()
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