using educae.contas.domain;

namespace educae.contas.app.ViewModels;
public class  AlunoViewModel 
{
    public Guid AlunoId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int TipoUsuario { get; set; } 
    public string Matricula { get; set; }

    public static AlunoViewModel Mapear (Aluno aluno)
    {
        return new AlunoViewModel()
        {
            AlunoId = aluno.Id,
            Nome = aluno.Nome,
            Email = aluno.Login.Email.Endereco,
            TipoUsuario = (int)aluno.TipoUsuario,
            Matricula = aluno.Matricula
        };
    }
}