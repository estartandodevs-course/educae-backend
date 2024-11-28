using System;
using educae.contas.app.domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace educae.contas.app.domain;

public class Usuario : Entity, IAggregateRoot
{
  public string Nome { get; set; }
  public string Email { get; set; }
  public string Senha { get; set; }
  public TipoContaEnum TipoDeConta { get; set; }
}

public class Login
{

}
