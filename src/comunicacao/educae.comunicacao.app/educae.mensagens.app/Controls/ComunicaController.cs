using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace educae.comunicacao.app.educae.mensagens.app.Controls
{
    private List<Mensagem> mensagens = new List<Mensagem>();
    private int proximoIdMensagem = 1;
    private int proximoIdResposta = 1;

    // Aluno envia uma mensagem
    public void EnviarMensagem(string conteudo, string remetente)
    {
        mensagens.Add(new Mensagem
        {
            Id = proximoIdMensagem++,
            Conteudo = conteudo,
            Remetente = remetente,
            DataEnvio = DateTime.Now
        });
    }

    // Professor responde a uma mensagem
    public void ResponderMensagem(int mensagemId, string conteudo, string remetente)
    {
        var mensagem = mensagens.Find(m => m.Id == mensagemId);
        if (mensagem != null)
        {
            mensagem.Respostas.Add(new Resposta
            {
                Id = proximoIdResposta++,
                Conteudo = conteudo,
                Remetente = remetente,
                DataEnvio = DateTime.Now
            });
        }
    }

    // Listar todas as mensagens
    public List<Mensagem> ListarMensagens()
    {
        return mensagens;
    }

    // Aluno comenta na resposta
    public void AdicionarComentario(int mensagemId, int respostaId, string conteudo, string remetente)
    {
        var mensagem = mensagens.Find(m => m.Id == mensagemId);
        var resposta = mensagem?.Respostas.Find(r => r.Id == respostaId);
        if (resposta != null)
        {
            mensagem.Respostas.Add(new Resposta
            {
                Id = proximoIdResposta++,
                Conteudo = $"Comentário: {conteudo}",
                Remetente = remetente,
                DataEnvio = DateTime.Now
            });
        }
    }
}