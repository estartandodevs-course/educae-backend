using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class ComunicadoInputModel
    {
    [Required(ErrorMessage = "Por favor Adicione um titulo")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "Descreva o comunicado")]
    public string Imagem { get; set; }
    [Required(ErrorMessage = "Adicione uma imagem valida")]
    public DateTime DataExpiracao { get; set; }
    }
}