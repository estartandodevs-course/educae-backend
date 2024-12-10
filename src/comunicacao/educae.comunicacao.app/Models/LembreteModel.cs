using System.ComponentModel.DataAnnotations;

namespace educae.comunicacao.app.Models;

public class LembreteModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
}