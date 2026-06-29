using Xunit;
using Moq;
using Zsporting.Application.Services;
using Zsporting.Application.Interfaces;
using Zsporting.Domain;

namespace Zsporting.Tests;

public class EventoEsportivoServiceTests
{
    private readonly Mock<IEventoEsportivoRepository> _repoMock;
    private readonly EventoEsportivoService _service;

    public EventoEsportivoServiceTests()
    {
        _repoMock = new Mock<IEventoEsportivoRepository>();
        _service = new EventoEsportivoService(_repoMock.Object);
    }

    [Fact]
    public async Task ObterTodos_DeveRetornarListaDeEventos()
    {
        var eventos = new List<EventoEsportivo>
        {
            new EventoEsportivo { Id = 1, Titulo = "Futebol", Esporte = "Futebol", Local = "SP", DataHora = DateTime.UtcNow.AddDays(1), CriadorId = 1 },
            new EventoEsportivo { Id = 2, Titulo = "Tênis", Esporte = "Tênis", Local = "RJ", DataHora = DateTime.UtcNow.AddDays(2), CriadorId = 1 }
        };
        _repoMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(eventos);

       
        var resultado = await _service.ObterTodosAsync();

        
        Assert.Equal(2, resultado.Count());
    }

    [Fact]
    public async Task ObterPorId_EventoExistente_DeveRetornarEvento()
    {
        
        var evento = new EventoEsportivo { Id = 1, Titulo = "Futebol", Esporte = "Futebol", Local = "SP", DataHora = DateTime.UtcNow.AddDays(1), CriadorId = 1 };
        _repoMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(evento);

       
        var resultado = await _service.ObterPorIdAsync(1);

        
        Assert.NotNull(resultado);
        Assert.Equal("Futebol", resultado.Titulo);
    }

    [Fact]
    public async Task ObterPorId_EventoInexistente_DeveRetornarNull()
    {
       
        _repoMock.Setup(r => r.ObterPorIdAsync(999)).ReturnsAsync((EventoEsportivo?)null);

       
        var resultado = await _service.ObterPorIdAsync(999);

       
        Assert.Null(resultado);
    }

    [Fact]
    public async Task Adicionar_EventoFuturo_DevePersistir()
    {
        var novoEvento = new EventoEsportivo { Id = 1, Titulo = "Corrida", Esporte = "Atletismo", Local = "BH", DataHora = DateTime.UtcNow.AddDays(5), CriadorId = 1 };
        _repoMock.Setup(r => r.AdicionarAsync(novoEvento)).ReturnsAsync(novoEvento);

        
        var resultado = await _service.AdicionarAsync(novoEvento);

       
        Assert.Equal("Corrida", resultado.Titulo);
        _repoMock.Verify(r => r.AdicionarAsync(novoEvento), Times.Once);
    }

    [Fact]
    public async Task Adicionar_EventoPassado_DeveLancarExcecao()
    {
        
        var eventoPassado = new EventoEsportivo { Id = 1, Titulo = "Antigo", Esporte = "Futebol", Local = "SP", DataHora = DateTime.UtcNow.AddDays(-1), CriadorId = 1 };

        
        await Assert.ThrowsAsync<ArgumentException>(() => _service.AdicionarAsync(eventoPassado));
    }

    [Fact]
    public async Task Remover_EventoExistente_DeveExcluir()
    {
        
        _repoMock.Setup(r => r.RemoverAsync(1)).Returns(Task.CompletedTask);

        await _service.RemoverAsync(1);

      
        _repoMock.Verify(r => r.RemoverAsync(1), Times.Once);
    }
}
