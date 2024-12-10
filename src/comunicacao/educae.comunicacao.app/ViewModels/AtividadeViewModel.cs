using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.app.ViewModels;

public class AtividadeViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataMaximaEntrega { get; set; }
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }
    public static AtividadeViewModel Mapear ( Atividade atividade )
    { 
        return new AtividadeViewModel()
        {
            Titulo = atividade.Titulo,
            Descricao = atividade.Descricao,
            DataMaximaEntrega = atividade.DataMaximaEntrega,
            AvaliacaoDaExecucao = atividade.AvaliacaoDaExecucao,
            Feito = atividade.Feito
        };
    }
}