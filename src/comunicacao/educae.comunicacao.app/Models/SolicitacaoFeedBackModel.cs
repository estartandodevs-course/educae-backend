using System.ComponentModel.DataAnnotations;

namespace educae.comunicacao.app.Models;

public class SolicitacaoFeedBackModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Assunto { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Conteudo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public UsuarioModel EducadorDestinatario { get; set; }
    public UsuarioModel? AlunoRementente { get; set; }
    public bool EnvioAnonimo { get; set; }
    public bool Aberta { get; set; }
    public RespostaFeedBackModel? Resposta { get; set; }
}

public class UsuarioModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Email { get; set; }
    public string Foto { get; set; }
}

public class RespostaFeedBackModel
{
    public string? Resposta { get; set; }
    public DateTime? DataResposta { get; set; }
}

public class AtualizarSolicitacaoFeedBackModel
{
    public Guid SolicitacaoId { get; set; }
    public string Assunto { get; set; }
    public string Conteudo { get; set; }
}