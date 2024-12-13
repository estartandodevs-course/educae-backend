using educae.comunicacao.app.Application.Commands.Comunicados;
using Microsoft.AspNetCore.Mvc;
using educae.comunicacao.app.Application.Queries.Interfaces;
using EstartandoDevsCore.Mediator;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunicadosController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IComunicadoQuery _comunicadoQuery; 

        public ComunicadosController(IMediatorHandler mediatorHandler, IComunicadoQuery comunicadoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _comunicadoQuery = comunicadoQuery;
        }

       
        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarComunicado([FromBody] AdicionarComunicadoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _mediatorHandler.EnviarComando(command);

            if (resultado.IsValid)
                return Ok(new { message = "Comunicado adicionado com sucesso!" });

            return BadRequest(resultado.Errors);
        }

        
        [HttpPut("editar")]
        public async Task<IActionResult> EditarComunicado([FromBody] EditarComunicadoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _mediatorHandler.EnviarComando(command);

            if (resultado.IsValid)
                return Ok(new { message = "Comunicado editado com sucesso!" });

            return BadRequest(resultado.Errors);
        }

        
        [HttpGet("obter")]
        public async Task<IActionResult> ObterComunicados()
        {
            var comunicados = await _comunicadoQuery.ObterComunicados();

            if (!comunicados.Any())
                return NotFound(new { message = "Nenhum comunicado encontrado." });

            return Ok(comunicados);
        }

        
        [HttpGet("ativos")]
        public async Task<IActionResult> ObterComunicadosAtivos()
        {
            var comunicados = await _comunicadoQuery.ObterComunicadosAtivos();

            if (!comunicados.Any())
                return NotFound(new { message = "Nenhum comunicado ativo encontrado." });

            return Ok(comunicados);
        }

        
        [HttpGet("expirados")]
        public async Task<IActionResult> ObterComunicadosExpirados()
        {
            var comunicados = await _comunicadoQuery.ObterComunicadosExpirados();

            if (!comunicados.Any())
                return NotFound(new { message = "Nenhum comunicado expirado encontrado." });

            return Ok(comunicados);
        }
    }
}