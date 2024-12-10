namespace educae.comunicacao.domain.ValueObject;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    
    protected Usuario() {}

    public Usuario(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
}