namespace POO_Aula08.Interfaces;

public interface IReproduzivel
{
    string Titulo { get; } // Agora toda mídia precisa expor seu título
    bool EmReproducao { get; set; } // O contrato agora exige saber o status
    void Play();
    void Pause();
}