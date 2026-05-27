namespace POO_Aula08.Interfaces;

public interface IReproduzivel
{
    string Titulo { get; } // 👈 NOVO: Agora toda mídia precisa expor seu título
    void Play();
    void Pause();
}