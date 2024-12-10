using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.ValueObject;

namespace educae.comunicacao.app.ViewModels;


public class SolicitacaoFeedbackViewModel
{
    public string Assunto { get; set; }
    public string Conteudo { get; set; }
    public Guid EducadorDestinatarioId { get; set; }
    public string EducadorNome { get; set; }
    public string EducadorEmail { get; set; }
    public Guid? AlunoRemetenteId { get; set; }
    public string? AlunoNome { get; set; }
    public string? AlunoEmail { get; set; }
    public bool EnvioAnonimo { get; set; }
    public bool Aberta { get; set; }
    public string Resposta { get; set; }
    public string DataResposta { get; set; }

    public SolicitacaoFeedbackViewModel Mapear (SolicitacaoFeedback solicitacaoFeedback)
    {
        return new SolicitacaoFeedbackViewModel () 
        {
            Assunto = solicitacaoFeedback.Assunto,
            Conteudo = solicitacaoFeedback.Conteudo,
            EducadorDestinatarioId = solicitacaoFeedback.EducadorDestinatario.Id,
            EducadorNome = solicitacaoFeedback.EducadorDestinatario.Nome,
            EducadorEmail = solicitacaoFeedback.EducadorDestinatario.Email,
            AlunoRemetenteId = solicitacaoFeedback?.AlunoRementente.Id,
            AlunoNome = solicitacaoFeedback?.AlunoRementente.Nome,
            AlunoEmail = solicitacaoFeedback?.AlunoRementente.Email,
            EnvioAnonimo = solicitacaoFeedback.EnvioAnonimo,
            Aberta = solicitacaoFeedback.Aberta,
            Resposta = solicitacaoFeedback.Resposta.Resposta,
            DataResposta = solicitacaoFeedback.Resposta.DataResposta.ToString()        
        };
    }
}