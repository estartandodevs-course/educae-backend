using System.ComponentModel.DataAnnotations;

namespace educae.biblioteca.app.Models;

public class CartilhaModel
{
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Resumo { get; set; }
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Descricao { get; set; }
    public string Url {get; set;}
    [Required(ErrorMessage = "A propriedade {0} é obrigatória")]
    public string Autor { get; set; }
    public int QuantidadeDeAnexos { get; set; }
    public List<AnexoModel> Anexos {get; set;}
}

public class AnexoModel
{
    public string NomeArquivo { get; set; }
    public string NomeOriginal { get; set; }
}
