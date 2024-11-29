using educae.contas.app.domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace educae.contas.app.domain
{
  public class Usuario : Entity, IAggregateRoot
  {
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public TipoContaEnum TipoDeConta { get; private set; }
    public string? Matricula { get; private set; }
    public Cpf? CPF { get; private set; }

    public Usuario(string nome, string email, string senha, TipoContaEnum tipoDeConta, string? matricula = null, string? cpf = null)
    {
      if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome não pode ser vazio.");
      if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email não pode ser vazio.");
      if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("Senha não pode ser vazia.");

      Nome = nome.Trim();
      Email = email.Trim();
      Senha = senha;
      TipoDeConta = tipoDeConta;

      if (TipoDeConta == TipoContaEnum.Aluno)
      {
        if (string.IsNullOrWhiteSpace(matricula)) throw new ArgumentException("Matrícula é obrigatória para alunos.");

        Matricula = matricula.Trim();
      }

      if (TipoDeConta == TipoContaEnum.Professor)
      {
        if (string.IsNullOrWhiteSpace(cpf)) throw new ArgumentException("CPF é obrigatório para professores.");

        var cpfObjeto = new Cpf(cpf);

        if (!cpfObjeto.EstaValido()) throw new ArgumentException("CPF inválido.");
        CPF = cpfObjeto;
      }
    }
  }
}
