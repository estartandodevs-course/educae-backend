using educae.biblioteca.domain.Entities;
using educae.biblioteca.domain.ValueObject;

namespace educae.biblioteca.app.ViewModels;

public class CartilhaViewModel
{
    public Guid CartilhaId { get; set; }
    public string Titulo { get; set; }
    public string Resumo { get; set; }
    public string Descricao { get; set; }
    public string Url {get; set;}
    public string Autor { get; set; }
    public int QuantidadeDeAnexos { get; set; }
    public IEnumerable<AnexoViewModel> Anexos {get; set;}

    public static CartilhaViewModel Mapear(Cartilha cartilha)
    {
        return new CartilhaViewModel()
        {
            CartilhaId = cartilha.Id,
            Titulo = cartilha.Titulo,
            Resumo = cartilha.Resumo,
            Descricao = cartilha.Descricao,
            Url = cartilha.Url.link,
            Autor = cartilha.Autor,
            QuantidadeDeAnexos = cartilha.QuantidadeDeAnexos,
            Anexos = cartilha.Anexos.Select(AnexoViewModel.Mapear)
        };
    }
}

public class AnexoViewModel
{
    public string NomeArquivo { get; set; }
    public string NomeOriginal { get; set; }

    public static AnexoViewModel Mapear(Anexo anexo)
    {
        return new AnexoViewModel()
        {
            NomeArquivo = anexo.NomeArquivo,
            NomeOriginal = anexo.NomeOriginal,
        };
    }
}