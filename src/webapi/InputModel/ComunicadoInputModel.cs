using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class ComunicadoInputModel
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
}