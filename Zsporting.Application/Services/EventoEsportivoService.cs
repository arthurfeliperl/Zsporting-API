      using Zsporting.Application.Interfaces;
using Zsporting.Domain;

namespace Zsporting.Application.Services;

public class EventoEsportivoService : IEventoEsportivoService
{
    private readonly IEventoEsportivoRepository _repository;

    public EventoEsportivoService(IEventoEsportivoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EventoEsportivo>> ObterTodosAsync()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<EventoEsportivo?> ObterPorIdAsync(int id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task<EventoEsportivo> CriarAsync(EventoEsportivo evento)
    {

        
        return await _repository.CriarAsync(evento);
    }

    public async Task AtualizarAsync(EventoEsportivo evento)
    {
        await _repository.AtualizarAsync(evento);
    }

    public async Task DeletarAsync(int id)
    {
        await _repository.DeletarAsync(id);
    }
}