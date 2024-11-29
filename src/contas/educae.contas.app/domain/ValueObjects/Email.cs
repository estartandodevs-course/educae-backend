namespace educae.contas.app.domain
{
  public class Email
  {
    public string Value { get; private set; }

    public Email(string value)
    {
      if (string.IsNullOrWhiteSpace(value))
      {
        throw new ArgumentException("O e-mail não pode ser vazio ou nulo.");
      }

      if (!IsValidEmail(value))
      {
        throw new ArgumentException("O e-mail fornecido é inválido.");
      }

      Value = value;
    }

    private bool IsValidEmail(string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }

    public override string ToString()
    {
      return Value;
    }
  }
}