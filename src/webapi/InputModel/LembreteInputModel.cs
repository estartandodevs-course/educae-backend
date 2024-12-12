using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class LembreteInputModel
    {
        [Required(ErrorMessage = "Detalhes do lembrete")]
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
    }
}