using Microsoft.EntityFrameworkCore;
using Zsporting.Domain;
using Zsporting.Application.Interfaces;
using Zsporting.Infrastructure;

namespace Zsporting.Infrastructure.Repositories;

public class EventoEsportivoRepository : IEventoEsportivoRepository
{
    private readonly ZsportingDbContext _context;

    public EventoEsportivoRepository(ZsportingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventoEsportivo>> ObterTodosAsync() => await _context.EventosEsportivos.ToListAsync();

    public async Task<EventoEsportivo?> ObterPorIdAsync(int id) => await _context.EventosEsportivos.FindAsync(id);

    public async Task<EventoEsportivo> AdicionarAsync(EventoEsportivo evento)
    {
        _context.EventosEsportivos.Add(evento);
        await _context.SaveChangesAsync();
        return evento;
    }

    public async Task AtualizarAsync(EventoEsportivo evento)
    {
        _context.Entry(evento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var evento = await _context.EventosEsportivos.FindAsync(id);
        if (evento != null)
        {
            _context.EventosEsportivos.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}