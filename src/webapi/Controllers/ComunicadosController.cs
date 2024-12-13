using educae.comunicacao.app.Application.Commands.Comunicados;
using Microsoft.AspNetCore.Mvc;
using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.comunicacao.app.Models;
using EstartandoDevsCore.Mediator;
using EstartandoDevsWebApiCore.Controllers;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunicadosController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IComunicadoQuery _comunicadoQuery; 

        public ComunicadosController(IMediatorHandler mediatorHandler, IComunicadoQuery comunicadoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _comunicadoQuery = comunicadoQuery;
        }

       
        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarComunicado([FromBody] ComunicadoModel comunicado)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarComunicadoCommand(comunicado.Titulo, comunicado.Descricao, comunicado.Imagem, comunicado.DataExpiracao);
            
            var result = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(result);
        }

        
        [HttpPut("editar")]
        public async Task<IActionResult> EditarComunicado([FromBody] ComunicadoModel comunicado)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarComunicadoCommand(comunicado.Titulo, comunicado.Descricao, comunicado.Imagem, comunicado.DataExpiracao);

            var result = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(result);
        }

        
        [HttpGet("obter")]
        public async Task<IActionResult> ObterComunicados()
        {
            var comunicados = await _comunicadoQuery.ObterComunicados();

            if (!comunicados.Any())
            {
                AdicionarErro("Nenhum comunicado encontrado."); 
                return CustomResponse();
            }
            return CustomResponse(comunicados);
        }

        
        [HttpGet("ativos")]
        public async Task<IActionResult> ObterComunicadosAtivos()
        {
            var comunicados = await _comunicadoQuery.ObterComunicadosAtivos();

            if (!comunicados.Any())
            {
                AdicionarErro("Nenhum comunicado ativo encontrado.");
                return CustomResponse();
            };

            return CustomResponse(comunicados);
        }

        
        [HttpGet("expirados")]
        public async Task<IActionResult> ObterComunicadosExpirados()
        {
            var comunicados = await _comunicadoQuery.ObterComunicadosExpirados();

            if (!comunicados.Any())
            {
                AdicionarErro("Nenhum comunicado expirado encontrado.");
                return CustomResponse();
            }
            return CustomResponse(comunicados);
        }
    }
}