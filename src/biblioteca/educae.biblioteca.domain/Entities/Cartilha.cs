using educae.biblioteca.domain.ValueObject;
using EstartandoDevsCore.DomainObjects;

namespace educae.biblioteca.domain.Entities;

public class Cartilha : Entity, IAggregateRoot
{
    public string Titulo { get; private set; }
    public string Resumo { get; private set; }
    public string Descricao { get; private set; }
    public Url Url {get; private set;}
    public Usuario Autor { get; private set; }
    public int QuantidadeDeAnexos { get; private set; }
    private List<Anexo> _anexos;
    public IReadOnlyCollection<Anexo> Anexos => _anexos;

    protected Cartilha()
    {
        _anexos = new List<Anexo>();
    }

    public Cartilha(string titulo, string resumo, string descricao, Url url, Usuario autor)
    {
        Titulo = titulo;
        Resumo = resumo;
        Descricao = descricao;
        Url = url;
        Autor = autor;
    }

    public void AtribuirTitulo(string titulo) => Titulo = titulo;
    public void AtribuirResumo(string resumo) => Resumo = resumo;
    public void AtribuirDescricao(string descricao) => Descricao = descricao;
    public void AtribuirLink(Url link) => Url = link;
    public void AtribuirAutor(Usuario usuario) => Autor = usuario;

    public void AdicionarAnexo(Anexo anexo)
    {
        QuantidadeDeAnexos++;
        _anexos.Add(anexo);
    }

    public void RemoverAnexo(Anexo anexo)
    {
        QuantidadeDeAnexos--;
        _anexos.Remove(anexo);
    }

}