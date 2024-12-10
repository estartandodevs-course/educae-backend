

public class  AlunoViewModel 
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; } 
    public int TipoUsuario { get; set; } 
    public string Matricula { get; set; }

    public static AlunoViewModel Mapear (Aluno aluno)
    {
        return new AlunoViewModel()
        {
            Nome = aluno.Nome,
            Email = aluno.Email,
            Senha = aluno.Senha,
            TipoUsuario = aluno.TipoUsuario,
            Matricula = aluno.Matricula
        };
    }
}