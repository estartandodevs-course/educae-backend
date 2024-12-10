using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.app.ViewModels;

public class LembreteViewModel
{
    public Guid LembreteId { get; set; }
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
    

    public static LembreteViewModel Mapear (Lembrete lembrete)
    {
        return new LembreteViewModel()
        {
            LembreteId = lembrete.Id,
            Descricao = lembrete.Descricao,
            Concluido = lembrete.Concluido
        };
    }
}