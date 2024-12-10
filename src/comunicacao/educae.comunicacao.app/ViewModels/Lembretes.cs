using educae.comunicacao.domain.Entities;

namespace educae.comunicacao.app.ViewModels;

public class LembreteViewModel
{
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
    

    public static LembreteViewModel Mapear (Lembrete lembrete)
    {
        return new LembreteViewModel()
        {
        Descricao = lembrete.Descricao,
        Concluido = lembrete.Concluido
        };
    }
}