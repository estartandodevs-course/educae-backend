using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class AtividadeInputModel
    {
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public DateTime DataMaximaEntrega { get; set; }
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }
    }

}