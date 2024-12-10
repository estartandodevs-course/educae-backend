using EstartandoDevsCore.DomainObjects;

namespace educae.biblioteca.domain.Entities;

public class Cartilha : Entity, IAggregateRoot
{
    public string Titulo { get; private set; }
    public string Resumo { get; private set; }
    public string Descricao { get; private set; }
    public string Url {get; private set;}
    public int QuantidadeDeSalvos { get; private set; }
    //lista de anexos
    
}