namespace educae.comunicacao.domain.ValueObject;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Foto { get; private set; }
    
    protected Usuario() {}

    public Usuario(Guid id, string nome, string email, string foto)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Foto = foto;
    }
}