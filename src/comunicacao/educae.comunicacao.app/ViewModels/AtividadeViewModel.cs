using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.app.ViewModels;

public class AtividadeViewModel
{
    public Guid AtividadeId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string DataMaximaEntrega { get; set; }
    public int AvaliacaoDaExecucao { get; set; }
    public bool Feito { get; set; }
    
    public static AtividadeViewModel Mapear ( Atividade atividade )
    { 
        return new AtividadeViewModel()
        {
            AtividadeId = atividade.Id,
            Titulo = atividade.Titulo,
            Descricao = atividade.Descricao,
            DataMaximaEntrega = atividade.DataMaximaEntrega.ToString("dd/MM/yyyy"),
            AvaliacaoDaExecucao = atividade.AvaliacaoDaExecucao,
            Feito = atividade.Feito
        };
    }
}