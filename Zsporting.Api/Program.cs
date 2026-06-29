using Microsoft.EntityFrameworkCore;
using Zsporting.Application.Interfaces;
using Zsporting.Application.Services;
using Zsporting.Infrastructure;
using Zsporting.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ZsportingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEventoEsportivoRepository, EventoEsportivoRepository>();
builder.Services.AddScoped<IEventoEsportivoService, EventoEsportivoService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();