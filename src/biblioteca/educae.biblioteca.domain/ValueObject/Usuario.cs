namespace educae.biblioteca.domain.ValueObject;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    
    protected Usuario() { }

    public Usuario(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}