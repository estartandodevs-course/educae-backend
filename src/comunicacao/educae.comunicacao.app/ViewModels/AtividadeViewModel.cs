namespace educae.comunicacao.app.ViewModels;

public class AtvidadeViewModel
{
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMaximaEntrega { get; set; }
        public int AvaliacaoDaExecucao { get; set; }
        public bool Feito { get; set; }
            public static AtividadeViewModel Mapear (Atividade atividade)
            { 
                return new AtividadeViewModel()
                {
                    Titulo = atividade.titulo,
                    Descricao = atividade.descricao,
                    DataMaximaEntrega = atividade.dataMaximaEntrega,
                    AvaliacaoDaExecucao = atividade.avaliacaoDaExecucao,
                    Feito = atividade.feito
                };
            }
}

