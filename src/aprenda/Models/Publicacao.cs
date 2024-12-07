using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educae-backend.Models
{
    public class Publicacao
    {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public string Autor { get; set; } 
    public DateTime DataPublicacao { get; set; }
    public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}