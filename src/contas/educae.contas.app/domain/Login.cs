namespace educae.contas.app.domain
{
  public class Login(Email email, Senha senha)
  {
    public Email Email { get; private set; } = email;
    public Senha Senha { get; private set; } = senha;
  }
}
