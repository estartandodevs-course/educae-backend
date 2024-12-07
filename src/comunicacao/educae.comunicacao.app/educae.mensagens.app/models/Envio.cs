using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educae.comunicacao.app.educae.mensagens.app.models
{
    public class Mensagem
{
    public int Id { get; set; }
    public string Conteudo { get; set; }
    public string Remetente { get; set; }
    public DateTime DataEnvio { get; set; }
    public List<Resposta> Respostas { get; set; } = new List<Resposta>();
}
}