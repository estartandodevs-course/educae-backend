using EstartandoDevsCore.DomainObjects;

namespace educae.comunicacao.domain.Entities;

public class Lembrete : Entity, IAggregateRoot
{
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
    
    protected Lembrete() {}

    public Lembrete(string descricao, bool concluido)
    {
        Descricao = descricao;
        Concluido = concluido;
    }
    
    public void AtribuirDescricao(string descricao) => Descricao = descricao;
    public void ConcluirLembrete() => Concluido = true;
    public void DesconcluirLembrete() => Concluido = false;
}