using educae.comunicacao.domain.ValueObject;
using EstartandoDevsCore.DomainObjects;

namespace educae.comunicacao.domain.Entities;

public class SolicitacaoFeedback : Entity, IAggregateRoot
{
    public string Assunto { get; private set; }
    public string Conteudo { get; private set; }
    public Usuario EducadorDestinatario { get; private set; }
    public Usuario? AlunoRementente { get; private set; }
    public bool EnvioAnonimo { get; private set; }
    public bool Aberta { get; private set; }
    public RespostaFeedBack? Resposta { get; private set; }

    protected SolicitacaoFeedback() { }

    public SolicitacaoFeedback(string assunto, string conteudo, Usuario educadorDestinatario, Usuario? alunoRementente, bool envioAnonimo, bool aberta)
    {
        Assunto = assunto;
        Conteudo = conteudo;
        EducadorDestinatario = educadorDestinatario;
        AlunoRementente = alunoRementente;
        EnvioAnonimo = envioAnonimo;
        Aberta = aberta;
    }

    public void AtribuirAssunto(string assunto) => Assunto = assunto;
    public void AtribuirConteudo(string conteudo) => Conteudo = conteudo;
    public void AtribuirDestinatario(Usuario educador) => EducadorDestinatario = educador;
    public void AtribuirAlunoRementente(Usuario aluno) => AlunoRementente = aluno;
    public void EnviarAnonimamente() => EnvioAnonimo = true;
    public void EnviarComIdentificacao() => EnvioAnonimo = false;
    private void FecharSolicitacao() => Aberta = false;

    public void AdicionarResposta(RespostaFeedBack resposta)
    {
        if (!Aberta) return;
        Resposta = resposta;
        FecharSolicitacao();
    }
}