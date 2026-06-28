using Microsoft.AspNetCore.Mvc;
using Zsporting.Application.Interfaces;
using Zsporting.Domain;

namespace Zsporting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosEsportivosController : ControllerBase
{
    private readonly IEventoEsportivoService _eventoService;

    public EventosEsportivosController(IEventoEsportivoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventoEsportivo>>> ObterTodos()
    {
        var eventos = await _eventoService.ObterTodosAsync();
        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoEsportivo>> ObterPorId(int id)
    {
        var evento = await _eventoService.ObterPorIdAsync(id);
        if (evento == null)
        {
            return NotFound(new { message = "Evento esportivo não encontrado." });
        }
        return Ok(evento);
    }

    [HttpPost]
    public async Task<ActionResult<EventoEsportivo>> Criar([FromBody] EventoEsportivo evento)
    {
        var novoEvento = await _eventoService.CriarAsync(evento);
        return CreatedAtAction(nameof(ObterPorId), new { id = novoEvento.Id }, novoEvento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] EventoEsportivo evento)
    {
        if (id != evento.Id)
        {
            return BadRequest(new { message = "O ID da URL não corresponde ao ID do corpo da requisição." });
        }

        await _eventoService.AtualizarAsync(evento);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _eventoService.DeletarAsync(id);
        return NoContent();
    }
}