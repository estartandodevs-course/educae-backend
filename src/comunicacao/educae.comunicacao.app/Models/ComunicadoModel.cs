using System.ComponentModel.DataAnnotations;

namespace educae.comunicacao.app.Models;

public class ComunicadoModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Imagem { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public DateTime DataExpiracao { get; set; }
}