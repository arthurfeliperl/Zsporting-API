using Microsoft.EntityFrameworkCore;
using Zsporting.Domain;

namespace Zsporting.Infrastructure;

public class ZsportingDbContext : DbContext
{
    public ZsportingDbContext(DbContextOptions<ZsportingDbContext> options) : base(options) { }

    public DbSet<Atleta> Atletas { get; set; }
    public DbSet<EventoEsportivo> EventosEsportivos { get; set; }
}