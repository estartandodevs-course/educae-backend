using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.domain.ValueObject;

public class RespostaFeedBack
{
    public string Resposta { get; private set; }
    public DateTime DataResposta { get; private set; }
    // public Usuario Remetente { get; private set; }
    
    public virtual SolicitacaoFeedback SolicitacaoFeedback { get; private set; }
}