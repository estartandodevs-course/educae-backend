namespace educae.comunicacao.app.Models;

public class SolicitacaoFeedBackModel
{
    public string Assunto { get; set; }
    public string Conteudo { get; set; }
    public UsuarioModel EducadorDestinatario { get; set; }
    public UsuarioModel? AlunoRementente { get; set; }
    public bool EnvioAnonimo { get; set; }
    public bool Aberta { get; set; }
    public RespostaFeedBackModel? Resposta { get; set; }
}

public class UsuarioModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class RespostaFeedBackModel
{
    public string? Resposta { get; set; }
    public DateTime? DataResposta { get; set; }}