namespace POO_Aula08.Interfaces;

public class Video : IReproduzivel
{
    private string _titulo;
    private string _resolucao;

    public Video(string titulo, string resolucao)
    {
        _titulo = titulo;
        _resolucao = resolucao;
    }

    // Cumprindo o mesmo contrato, mas com comportamentos diferentes:
    public void Play()
    {
        Console.WriteLine($"▶️  Reproduzindo vídeo: '{_titulo}' na resolução {_resolucao}.");
    }

    public void Pause()
    {
        Console.WriteLine($"⏸️  Vídeo '{_titulo}' pausado. Buffering...");
    }
}