using EstartandoDevsCore.DomainObjects;

namespace educae.comunicacao.domain.Entities;

public class Comunicado : Entity, IAggregateRoot
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Imagem { get; private set; }
    public DateTime DataExpiracao { get; private set; }
    
    protected Comunicado() { }

    public Comunicado(string titulo, string descricao, string imagem, DateTime dataExpiracao)
    {
        Titulo = titulo;
        Descricao = descricao;
        Imagem = imagem;
        DataExpiracao = dataExpiracao;
    }

    public void AtribuirTitulo(string titulo) => Titulo = titulo;
    public void AtribuirDescricao(string descricao) => Descricao = descricao;
    public void AtribuirImagem(string imagem) => Imagem = imagem;
    public void AtribuirDataExpiracao(DateTime data) => DataExpiracao = data;

    public bool EstaExpirado()
    {
        if (DataExpiracao < DateTime.Now) return true;
        return false;
    }
}