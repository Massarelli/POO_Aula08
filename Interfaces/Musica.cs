namespace POO_Aula08.Interfaces;

public class Musica : IReproduzivel
{
    // Usando o seu novo padrão Microsoft de nomenclatura!
    private string _titulo;
    private string _artista;

    public Musica(string titulo, string artista)
    {
        _titulo = titulo;
        _artista = artista;
    }

    // Cumprindo o contrato:
    public void Play()
    {
        Console.WriteLine($"▶️  A tocar a música: '{_titulo}' de {_artista}.");
    }

    public void Pause()
    {
        Console.WriteLine($"⏸️  Música '{_titulo}' pausada.");
    }
}