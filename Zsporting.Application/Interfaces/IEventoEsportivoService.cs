using Zsporting.Domain;

namespace Zsporting.Application.Interfaces;

public interface IEventoEsportivoService
{
    Task<IEnumerable<EventoEsportivo>> ObterTodosAsync();
    Task<EventoEsportivo?> ObterPorIdAsync(int id);
    Task<EventoEsportivo> CriarAsync(EventoEsportivo evento);
    Task AtualizarAsync(EventoEsportivo evento);
    Task DeletarAsync(int id);
}