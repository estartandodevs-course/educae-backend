namespace educae.biblioteca.app.Models;

public class CartilhaModel
{
    public string Titulo { get; set; }
    public string Resumo { get; set; }
    public string Descricao { get; set; }
    public string Url {get; set;}
    public string Autor { get; set; }
    public int QuantidadeDeAnexos { get; set; }
    public List<AnexoModel> Anexos {get; set;}
}

public class AnexoModel
{
    public string NomeArquivo { get; set; }
    public string NomeOriginal { get; set; }
}
