using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.domain.ValueObject;

public class RespostaFeedBack
{
    public string? Resposta { get; private set; }
    public DateTime? DataResposta { get; private set; }
    
    protected RespostaFeedBack() {}

    public RespostaFeedBack(string? resposta, DateTime? dataResposta)
    {
        Resposta = resposta;
        DataResposta = dataResposta;
    }
}