using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.app.ViewModels;


public class SolicitacaoFeedbackViewModel
{
    public string Assunto { get; set; }
    public string Conteudo { get; set; }
    public Usuario EducadorDestinatario { get; set; }
    public Usuario? AlunoRementente { get; set; }
    public bool EnvioAnonimo { get; set; }
    public bool Aberta { get; set; }
    public RespostaFeedBack? Resposta { get; set; }

    public SolicitacaoFeedbackViewModel Mapear (SolicitacaoFeedback solicitacaoFeedback)
    {
        return new SolicitacaoFeedbackViewModel () 
        {
        Assunto = solicitacaoFeedback.assunto,
        Conteudo = solicitacaoFeedback.conteudo,
        EducadorDestinatario = solicitacaoFeedback.educadorDestinatario,
        AlunoRementente = solicitacaoFeedback.alunoRementente,
        EnvioAnonimo = solicitacaoFeedback.envioAnonimo,
        Aberta = solicitacaoFeedback.aberta
        };
    }
}