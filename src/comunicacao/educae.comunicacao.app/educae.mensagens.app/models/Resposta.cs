using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educae.comunicacao.app.educae.mensagens.app.models
{
    public class Resposta
    {
    public int Id { get; set; }
    public string Conteudo { get; set; }
    public string Remetente { get; set; }
    public DateTime DataEnvio { get; set; }

    }
}