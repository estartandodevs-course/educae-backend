using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.InputModel
{
    public class SolicitacaoInputModel
    {
    
    [Required(ErrorMessage = " Qual é o assunto ? ")]
    public string Assunto { get; set; }

    [Required(ErrorMessage = " Escreva aqui o conteudo ")] 
    public string Conteudo { get; set; }
    
    [Required(ErrorMessage = " Escreva o destinatario da Solicitação ")]
    public UsuarioModel EducadorDestinatario { get; set; }
    
    public UsuarioModel? AlunoRementente { get; set; }
    public bool EnvioAnonimo { get; set; }
    public bool Aberta { get; set; }
    public RespostaFeedBackModel? Resposta { get; set; }
    }
}