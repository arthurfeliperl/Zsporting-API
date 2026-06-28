namespace Zsporting.Domain;

public class EventoEsportivo
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Esporte { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public int CriadorId { get; set; }
}