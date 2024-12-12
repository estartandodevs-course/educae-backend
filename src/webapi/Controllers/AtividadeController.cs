using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using educae.comunicacao.app.Models;

namespace src.Controllers
{
    [Route("[controller]")]
    public class AtividadesController : ControllerBase
    {
        private static readonly List<AtividadeModel> _atividades = new List<AtividadeModel>();

        // Endpoint: GET api/atividades (Listar todas as atividades)
        [HttpGet]
        public IActionResult ListarAtividades()
        {
            return Ok(_atividades);
        }

        // Endpoint: GET api/atividades/{id} (Obter uma atividade pelo índice na lista)
        [HttpGet("{id}")]
        public IActionResult ObterAtividade(int id)
        {
            if (id < 0 || id >= _atividades.Count)
                return NotFound($"Atividade com ID {id} não encontrada.");

            return Ok(_atividades[id]);
        }

        // Endpoint: POST api/atividades (Criar uma nova atividade)
        [HttpPost]
        public IActionResult CriarAtividade([FromBody] AtividadeModel novaAtividade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _atividades.Add(novaAtividade);
            return CreatedAtAction(nameof(ObterAtividade), new { id = _atividades.Count - 1 }, novaAtividade);
        }

        // Endpoint: PUT api/atividades/{id} (Atualizar uma atividade existente)
        [HttpPut("{id}")]
        public IActionResult AtualizarAtividade(int id, [FromBody] AtividadeModel atividadeAtualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id < 0 || id >= _atividades.Count)
                return NotFound($"Atividade com ID {id} não encontrada.");

            _atividades[id] = atividadeAtualizada;
            return Ok(atividadeAtualizada);
        }

        // Endpoint: DELETE api/atividades/{id} (Remover uma atividade)
        [HttpDelete("{id}")]
        public IActionResult RemoverAtividade(int id)
        {
            if (id < 0 || id >= _atividades.Count)
                return NotFound($"Atividade com ID {id} não encontrada.");

            _atividades.RemoveAt(id);
            return NoContent();
        }
    }
}
