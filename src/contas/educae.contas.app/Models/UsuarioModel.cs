using System.ComponentModel.DataAnnotations;

namespace educae.contas.app.Models;

public class UsuarioModel 
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Email { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public int TipoUsuario { get; set; }
}

public class EducadorModel : UsuarioModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Cpf { get; set; }
}

public class AlunoModel : UsuarioModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Matricula { get; set; }
}