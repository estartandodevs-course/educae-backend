using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class AtividadeInputModel
    {
    [Required(ErrorMessage = "De um titulo a atividade")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "Descreva a atividade")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "Data limite para a atividade")]
    public DateTime DataMaximaEntrega { get; set; }
    
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }
    }

}