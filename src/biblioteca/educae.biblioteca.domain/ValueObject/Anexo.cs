namespace educae.biblioteca.domain.ValueObject;

public class Anexo
{
    public string NomeArquivo { get; set; }
    public string NomeOriginal { get; set; }

    protected Anexo(){}

    public Anexo(string nomeArquivo, string nomeOriginal)
    {
        NomeArquivo = nomeArquivo;
        NomeOriginal = nomeOriginal;
    }
}