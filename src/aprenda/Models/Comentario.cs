using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace educae-backend.src.aprenda.educae.app.Controls.Models
{
    [Route("[controller]")]
    public class PublicacaoController : Controller
    {
        private List<Publicacao> publicacoes = new List<Publicacao>();
        private int proximoIdPublicacao = 1;
        private int proximoIdComentario = 1;
        private readonly ILogger<PublicacaoController> _logger;


    public void CriarPublicacao(string titulo, string conteudo, string autor)
        {
            publicacoes.Add(new Publicacao
            {
                Id = proximoIdPublicacao++,
                Titulo = titulo,
                Conteudo = conteudo,
                Autor = autor,
                DataPublicacao = DateTime.Now
            });
        }

    public void AdicionarComentario(int publicacaoId, string conteudo, string autor)
    {
        var publicacao = publicacoes.Find(p => p.Id == publicacaoId);
        if (publicacao != null)
        {
            publicacao.Comentarios.Add(new Comentario
            {
                Id = proximoIdComentario++,
                Conteudo = conteudo,
                Autor = autor,
                DataComentario = DateTime.Now
            });
        }
    }

    public List<Publicacao> ListarPublicacoes()
    {
        return publicacoes;
    }
}
}