using Zsporting.Domain;
using Zsporting.Application.Interfaces;

namespace Zsporting.Application.Services;

public class EventoEsportivoService : IEventoEsportivoService
{
    private readonly IEventoEsportivoRepository _repository;

    public EventoEsportivoService(IEventoEsportivoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EventoEsportivo>> ObterTodosAsync() => await _repository.ObterTodosAsync();

    public async Task<EventoEsportivo?> ObterPorIdAsync(int id) => await _repository.ObterPorIdAsync(id);

    public async Task<EventoEsportivo> AdicionarAsync(EventoEsportivo evento)
    {
        if (evento.DataHora < DateTime.UtcNow)
            throw new ArgumentException("A data do evento deve ser no futuro.");

        return await _repository.AdicionarAsync(evento);
    }

    public async Task AtualizarAsync(EventoEsportivo evento) => await _repository.AtualizarAsync(evento);

    public async Task RemoverAsync(int id) => await _repository.RemoverAsync(id);
}