using educae.contas.domain;

namespace educae.contas.app.ViewModels;
public class  EducadorViewModel 
{
    public Guid EducadorId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int TipoUsuario { get; set; } 
    public string Cpf { get; set; }

    public static EducadorViewModel Mapear (Educador educador) 
    {
        return new EducadorViewModel()
        {
            EducadorId = educador.Id,
            Nome = educador.Nome,
            Email = educador.Email.Endereco,
            TipoUsuario = (int)educador.TipoUsuario,
            Cpf = educador.CPF.Numero
        };
    }
}