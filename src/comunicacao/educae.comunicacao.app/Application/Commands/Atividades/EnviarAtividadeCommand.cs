using EstartandoDevsCore.Messages;
using FluentValidation;

namespace educae.comunicacao.app.Application.Commands.Atividades;

public class EnviarAtividadeCommand : Command
{
    public Guid AtividadeId { get; set; }
    public int AvaliacaoAtividade { get; set; }
    public bool Feito { get; set; }

    public EnviarAtividadeCommand(Guid atividadeId, int avaliacaoAtividade, bool feito)
    {
        AtividadeId = atividadeId;
        AvaliacaoAtividade = avaliacaoAtividade;
        Feito = feito;
    }

    public override bool EstaValido()
    {
        ValidationResult = new EnviarAtividadeValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class EnviarAtividadeValidation : AbstractValidator<EnviarAtividadeCommand>
    {
        public EnviarAtividadeValidation()
        {
            RuleFor(x => x.AvaliacaoAtividade)
                .NotEqual(0).WithMessage("A nota da avaliação da execução da atividade não pode ser igual a zero");
        }
    }
        
}