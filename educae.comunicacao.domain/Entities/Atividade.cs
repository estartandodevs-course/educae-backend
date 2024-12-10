using EstartandoDevsCore.DomainObjects;

namespace educae.comunicacao.domain.Entities;

public class Atividade : Entity, IAggregateRoot
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataMaximaEntrega { get; private set; }
    public int AvaliacaoDaExecucao { get; private set; }
    public bool Feito { get; private set; }
    
    protected Atividade() {}

    public Atividade(string titulo, string descricao, DateTime dataMaximaEntrega, int avaliacaoDaExecucao, bool feito)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataMaximaEntrega = dataMaximaEntrega;
        AvaliacaoDaExecucao = avaliacaoDaExecucao;
        Feito = feito;
    }

    public void AtribuirTitulo(string titulo) => Titulo = titulo;
    public void AtribuirDescricao(string descricao) => Descricao = descricao;
    public void AtribuirDataMaximaEntrega(DateTime dataMaximaEntrega) => DataMaximaEntrega = dataMaximaEntrega;
    public void AtribuirEstrelas(int avaliacaoDaExecucao) => AvaliacaoDaExecucao = avaliacaoDaExecucao;
    public void MarcarFeito() => Feito = true;
    public void DesmarcarFeito() => Feito = false;

    public bool EstaAtrasada()
    {
        if (DateTime.Now > DataMaximaEntrega && Feito == false) return true;
        
        return false;
    }
    
    
    
}